using UnityEngine;

namespace SpawnPoint
{
    public interface ISpawnPoint
    {
        GameObject Spawn(Vector3 position);
    }
}