using UnityEngine;

namespace SpawnPoint
{
    public class BaseSpawnPoint : MonoBehaviour, ISpawnPoint
    {
        public void Spawn(Vector3Int position)
        {
            Debug.Log("Spawn base object");
        }
    }
}