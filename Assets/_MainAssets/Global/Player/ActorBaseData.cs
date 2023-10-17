using System;
using DamageSystem;
using Leveling;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ActorData/Base", order = 1)]
    [Serializable]
    public class ActorBaseData : ScriptableObject
    {
        public BaseLevel baseLevel;
        public DamageStatsSo damageStats;
    }
}