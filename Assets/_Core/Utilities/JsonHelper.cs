using System;
using UnityEngine;

namespace Utilities
{
    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            var wrapper = JsonUtility.FromJson<WrapperArray<T>>(json);
            return wrapper.items;
        }

        public static string ToJson<T>(T[] array)
        {
            var wrapper = new WrapperArray<T>
            {
                items = array
            };
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            var wrapper = new WrapperArray<T>
            {
                items = array
            };
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        public static string FixJson(string value)
        {
            value = "{\"Items\":" + value + "}";
            return value;
        }

        [Serializable]
        private class WrapperArray<T>
        {
            public T[] items;
        }
    }
}