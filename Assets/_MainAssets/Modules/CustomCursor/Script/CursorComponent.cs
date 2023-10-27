using UnityEngine;

namespace CustomCursor
{
    public class CursorComponent : MonoBehaviour
    {
        [SerializeField] internal Texture2D cursorTexture;
        [SerializeField] internal ParticleSystem particleCursor;

        internal bool IsPlaying => particleCursor.isPlaying;
    }
}