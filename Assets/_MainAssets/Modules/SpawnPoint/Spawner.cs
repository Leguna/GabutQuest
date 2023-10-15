using System;
using UnityEngine;

namespace SpawnPoint
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private SpawnPointTilemap spawnPointTilemap;
        [SerializeField] private EnemySpawnPoint enemySpawnPoint;
        [SerializeField] private PlayerSpawnPoint playerSpawnPoint;

        private void Awake()
        {
            TryGetComponent(out spawnPointTilemap);
            spawnPointTilemap.Init();
            Spawn();
        }

        private void Spawn()
        {
            foreach (var spawnPointTilemapData in spawnPointTilemap.spawnPointTilemapDatas)
            {
                BaseSpawnPoint spawnPoint;
                switch (spawnPointTilemapData.typeSpawnPoint)
                {
                    case TypeSpawnPoint.Player:
                        spawnPoint = Instantiate(playerSpawnPoint);
                        break;
                    case TypeSpawnPoint.Enemy:
                        spawnPoint = Instantiate(enemySpawnPoint);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                spawnPoint.transform.position = spawnPointTilemapData.position;
                spawnPoint.Spawn(spawnPointTilemapData.position);
            }
        }
    }
}