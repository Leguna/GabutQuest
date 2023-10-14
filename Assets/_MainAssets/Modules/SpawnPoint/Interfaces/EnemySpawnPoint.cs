using UnityEngine;

namespace SpawnPoint
{
    public class EnemySpawnPoint : ISpawnPoint
    {
        public void Spawn(Vector3Int position)
        {
            Debug.Log("Spawn enemy");
        }
    }
}