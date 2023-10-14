using UnityEngine;

namespace SpawnPoint
{
    public class EnemySpawnPoint : BaseSpawnPoint
    {
        public new void Spawn(Vector3Int position)
        {
            Debug.Log("Spawn enemy");
        }
    }
}