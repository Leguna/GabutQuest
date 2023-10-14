using UnityEngine;

namespace SpawnPoint
{
    public class Spawner : MonoBehaviour
    {
        private readonly SpawnPointTilemap.SpawnPointTilemapData[] _spawnPointTilemapDatas;

        public Spawner(SpawnPointTilemap.SpawnPointTilemapData[] spawnPointTilemapDatas)
        {
            _spawnPointTilemapDatas = spawnPointTilemapDatas;
        }

        public void Spawn()
        {
            foreach (var spawnPointTilemapData in _spawnPointTilemapDatas)
            {
                var spawnPoint = SpawnPointFactory.Create(spawnPointTilemapData.typeSpawnPoint);
                spawnPoint.Spawn(spawnPointTilemapData.position);
            }
        }
    }
}