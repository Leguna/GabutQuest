using System;
using Actor;
using DamageModule;
using SpawnPoint;
using UnityEngine;

namespace Spawn
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private SpawnPointTilemap spawnPointTilemap;
        [SerializeField] private EnemySpawnPoint enemySpawnPoint;
        [SerializeField] private PlayerSpawnPoint playerSpawnPoint;

        private PlayerSystem _playerSystem;
        private DamageSystem _damageSystem;

        public void Init(DamageSystem damageSystem)
        {
            _damageSystem = damageSystem;
            TryGetComponent(out spawnPointTilemap);
            spawnPointTilemap.Init();
            Spawn();
        }

        private void Spawn()
        {
            foreach (var data in spawnPointTilemap.spawnPointTilemapDatas)
            {
                switch (data.typeSpawnPoint)
                {
                    case TypeSpawnPoint.Player:
                        _playerSystem = Instantiate(playerSpawnPoint, data.position, Quaternion.identity, transform)
                            .Spawn();
                        _playerSystem.Init();
                        break;
                    case TypeSpawnPoint.Enemy:
                        var enemySpawnPointObject =
                            Instantiate(enemySpawnPoint, data.position, Quaternion.identity, transform);
                        var enemySystem = enemySpawnPointObject.Spawn(enemySpawnPointObject.transform);
                        enemySystem.Init(_damageSystem);
                        break;
                    case TypeSpawnPoint.None:
                    case TypeSpawnPoint.Boss:
                    case TypeSpawnPoint.Item:
                    case TypeSpawnPoint.Trap:
                    case TypeSpawnPoint.Portal:
                    case TypeSpawnPoint.Npc:
                    case TypeSpawnPoint.Other:
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}