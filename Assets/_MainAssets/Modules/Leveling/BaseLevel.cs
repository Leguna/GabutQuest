using System;
using UnityEngine;

namespace Leveling
{
    [Serializable]
    public class BaseLevel
    {
        public int Level;
        public int Exp;
        public int MaxExp;
        public int MaxLevel;
        public int Ascension;
        public int MaxAscension;
        public int Refinement;
        public int MaxRefinement;

        public BaseLevel(int level, int exp, int maxExp, int maxLevel, int ascension, int maxAscension, int refinement,
            int maxRefinement)
        {
            Level = level;
            Exp = exp;
            MaxExp = maxExp;
            MaxLevel = maxLevel;
            Ascension = ascension;
            MaxAscension = maxAscension;
            Refinement = refinement;
            MaxRefinement = maxRefinement;
        }

        public BaseLevel()
        {
            Level = 1;
            Exp = 0;
            MaxExp = 100;
            MaxLevel = 100;
            Ascension = 0;
            MaxAscension = 10;
            Refinement = 0;
            MaxRefinement = 10;
        }

        public void AddExp(int exp)
        {
            Exp += exp;
            if (Exp < MaxExp) return;
            Exp -= MaxExp;
            Level++;
            if (Level < MaxLevel) return;
            Level = MaxLevel;
            Exp = 0;
        }

        public void AddAscension(int ascension)
        {
            Ascension += ascension;
            if (Ascension < MaxAscension) return;
            Ascension -= MaxAscension;
            Refinement++;
            if (Refinement < MaxRefinement) return;
            Refinement = MaxRefinement;
            Ascension = 0;
        }

        public void AddRefinement(int refinement)
        {
            Refinement += refinement;
            if (Refinement < MaxRefinement) return;
            Refinement -= MaxRefinement;
            Ascension++;
            if (Ascension < MaxAscension) return;
            Ascension = MaxAscension;
            Refinement = 0;
        }

        public BaseLevel FromJson(string json)
        {
            return JsonUtility.FromJson<BaseLevel>(json);
        }

        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }
    }
}