using UnityEngine;

namespace SpawnPoint
{
    public interface ISpawnPoint<out T>
    {
        T Spawn(Transform targetTransform);
    }
}