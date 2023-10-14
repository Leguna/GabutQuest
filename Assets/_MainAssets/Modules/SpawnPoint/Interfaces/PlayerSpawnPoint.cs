using UnityEngine;

namespace SpawnPoint
{
    public class PlayerSpawnPoint : ISpawnPoint
    {
        public void Spawn(Vector3Int position)
        {
            Debug.Log("Spawn player");
        }
    }
}