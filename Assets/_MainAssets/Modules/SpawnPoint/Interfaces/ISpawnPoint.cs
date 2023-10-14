using UnityEngine;

namespace SpawnPoint
{
    public interface ISpawnPoint
    {
        void Spawn(Vector3Int position);
    }
}