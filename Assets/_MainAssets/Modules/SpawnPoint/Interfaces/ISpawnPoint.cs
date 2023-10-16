using UnityEngine;

namespace SpawnPoint
{
    public interface ISpawnPoint
    {
        GameObject Spawn(Transform targetTransform);
    }
}