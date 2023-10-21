using UnityEngine;
using Utilities;

namespace ToastModal
{
    public class ToastSystem : SingletonMonoBehaviour<ToastSystem>
    {
        [SerializeField] private Toast toast;
        [SerializeField] private ToastPool toastPool;

        protected override void Awake()
        {
            base.Awake();
            Init();
        }

        private void Init()
        {
            toastPool = Instantiate(toastPool, transform);
            toastPool.Init(toast, 5);
        }

        public void OnGUI()
        {
            if (GUI.Button(new Rect(10, 10, 150, 100), "Show Toast"))
            {
                Show("Hello World");
            }
        }

        public static void Show(string message, float duration = 1f) =>
            Instance.toastPool.GetObject().Show(message, duration);
    }
}