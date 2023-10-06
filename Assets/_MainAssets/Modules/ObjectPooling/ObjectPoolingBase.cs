using UnityEngine;

namespace ObjectPooling
{
    public class ObjectPoolingBase<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private T prefab;
        [SerializeField] private int poolSize;

        private T[] pool;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            pool = new T[poolSize];
            for (int i = 0; i < poolSize; i++)
            {
                pool[i] = Instantiate(prefab, transform);
                pool[i].gameObject.SetActive(false);
            }
        }

        public T GetObject()
        {
            for (int i = 0; i < poolSize; i++)
            {
                if (!pool[i].gameObject.activeInHierarchy)
                {
                    return pool[i];
                }
            }

            return null;
        }
    }
}