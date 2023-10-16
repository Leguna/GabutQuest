using UnityEngine;
using UnityEngine.Serialization;

namespace SpawnPoint
{
    public class BaseSpawnPoint : MonoBehaviour, ISpawnPoint
    {
        [SerializeField] private GameObject spawnedGameObject;

        public virtual GameObject Spawn(Transform targetTransform)
        {
            return Instantiate(spawnedGameObject, targetTransform.position, targetTransform.rotation);
        }
    }
}