using System;
using DamageModule;
using Leveling;
using UnityEngine;
using Utilities;

namespace Actor
{
    [CreateAssetMenu(fileName = "ActorBaseData", menuName = "ActorData/Base", order = 1)]
    [Serializable]
    public class ActorBaseData : BaseSo
    {
        public BaseLevel baseLevel;
        public DamageStatsSo damageStats;
    }
}