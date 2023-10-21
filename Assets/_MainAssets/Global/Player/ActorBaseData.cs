using System;
using DamageSystem;
using Leveling;
using UnityEngine;
using Utilities;

namespace Player
{
    [CreateAssetMenu(fileName = "ActorBaseData", menuName = "ActorData/Base", order = 1)]
    [Serializable]
    public class ActorBaseData : BaseSo
    {
        public BaseLevel baseLevel;
        public DamageStatsSo damageStats;
    }
}