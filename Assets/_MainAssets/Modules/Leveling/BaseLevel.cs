using System;
using UnityEngine;

namespace Leveling
{
    [Serializable]
    public class BaseLevel
    {
        public int level;
        public int exp;
        public int maxExp;
        public int maxLevel;
        public int ascension;
        public int maxAscension;
        public int refinement;
        public int maxRefinement;

        public BaseLevel(int level, int exp, int maxExp, int maxLevel, int ascension, int maxAscension, int refinement,
            int maxRefinement)
        {
            this.level = level;
            this.exp = exp;
            this.maxExp = maxExp;
            this.maxLevel = maxLevel;
            this.ascension = ascension;
            this.maxAscension = maxAscension;
            this.refinement = refinement;
            this.maxRefinement = maxRefinement;
        }

        public BaseLevel()
        {
            level = 1;
            exp = 0;
            maxExp = 10;
            maxLevel = 100;
            ascension = 0;
            maxAscension = 10;
            refinement = 0;
            maxRefinement = 10;
        }

        public void AddExp(int newExp)
        {
            exp += newExp;
            if (exp < maxExp) return;
            exp -= maxExp;
            level++;
            if (level < maxLevel) return;
            level = maxLevel;
            exp = 0;
        }

        public void AddAscension(int addAscension)
        {
            ascension += addAscension;
            if (ascension < maxAscension) return;
            ascension -= maxAscension;
            refinement++;
            if (refinement < maxRefinement) return;
            refinement = maxRefinement;
            ascension = 0;
        }

        public void AddRefinement(int addRefinement)
        {
            refinement += addRefinement;
            if (refinement < maxRefinement) return;
            refinement -= maxRefinement;
            ascension++;
            if (ascension < maxAscension) return;
            ascension = maxAscension;
            refinement = 0;
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