using System;

namespace SpawnPoint
{
    public abstract class SpawnPointFactory
    {
        public static ISpawnPoint Create(TypeSpawnPoint typeSpawnPoint)
        {
            return typeSpawnPoint switch
            {
                TypeSpawnPoint.Player => new PlayerSpawnPoint(),
                TypeSpawnPoint.Enemy => new EnemySpawnPoint(),
                _ => throw new ArgumentOutOfRangeException(nameof(typeSpawnPoint), typeSpawnPoint, null)
            };
        }
    }
}