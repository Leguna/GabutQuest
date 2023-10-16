using Player;
using UnityEngine;

namespace SpawnPoint
{
    public class PlayerSpawnPoint : BaseSpawnPoint
    {
        public override GameObject Spawn(Transform position)
        {
            // Dont Spawn if player already exist
            var playerSystem = FindObjectOfType<PlayerSystem>();
            return playerSystem != null ? playerSystem.gameObject : base.Spawn(position);
        }

        public PlayerSystem Spawn()
        {
            return Spawn(transform).GetComponent<PlayerSystem>();
        }
    }
}