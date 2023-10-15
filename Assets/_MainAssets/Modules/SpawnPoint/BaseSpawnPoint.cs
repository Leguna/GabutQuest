using UnityEngine;

namespace SpawnPoint
{
    public class BaseSpawnPoint : MonoBehaviour, ISpawnPoint
    {
        [SerializeField] private GameObject spawnedGameObject;

        public virtual GameObject Spawn(Vector3 position)
        {
            Debug.Log("Spawn base object");
            return Instantiate(spawnedGameObject, position, Quaternion.identity);
        }
    }
}