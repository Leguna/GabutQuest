using Actor;
using UnityEngine;

namespace SpawnPoint
{
    public class PlayerSpawnPoint : BaseSpawnPoint<PlayerSystem>
    {
        public override PlayerSystem Spawn(Transform position)
        {
            var playerSystem = FindObjectOfType<PlayerSystem>();
            return playerSystem != null ? playerSystem : base.Spawn(position);
        }

        public PlayerSystem Spawn()
        {
            return Spawn(transform);
        }
    }
}