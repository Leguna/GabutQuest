using UnityEngine;

namespace SpawnPoint
{
    public class PlayerSpawnPoint : BaseSpawnPoint
    {
        public new void Spawn(Vector3Int position)
        {
            Debug.Log("Spawn player");
        }
    }
}