using UnityEngine;

namespace CustomCursor
{
    public class CursorTesting : MonoBehaviour
    {
        [SerializeField] private Texture2D cursorTexture;
        [SerializeField] private ParticleSystem particleCursor;

        void Start()
        {
            var cursorManager = FindObjectOfType<CursorManager>();
            cursorManager.Init(cursorTexture, particleCursor);
            cursorManager.SpawnParticleCursor(particleCursor);
            cursorManager.SetIsForceLocked(true);
        }
    }
}