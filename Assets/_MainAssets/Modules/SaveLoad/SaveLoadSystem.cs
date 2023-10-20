﻿using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SaveLoad
{
    public class SaveLoadSystem
    {
        private static readonly string _saveFolder = "SaveData";
        private static readonly string _saveExtension = ".sav";

        public static void Save(ISaveable saveable)
        {
            var saveObject = saveable.CaptureState();
            var path = GetPathFromSaveable(saveable);
            using (var stream = File.Open(path, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, saveObject);
            }
        }

        public static void Load(ISaveable saveable)
        {
            var path = GetPathFromSaveable(saveable);
            using (var stream = File.Open(path, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                var saveObject = formatter.Deserialize(stream);
                saveable.RestoreState(saveObject);
            }
        }

        public static void Delete(ISaveable saveable)
        {
            var path = GetPathFromSaveable(saveable);
            File.Delete(path);
        }

        private static string GetPathFromSaveable(ISaveable saveable)
        {
            var saveFolder = Path.Combine(Application.persistentDataPath, _saveFolder);
            if (!Directory.Exists(saveFolder))
            {
                Directory.CreateDirectory(saveFolder);
            }

            return Path.Combine(saveFolder, saveable.GetUniqueIdentifier() + _saveExtension);
        }
    }
}