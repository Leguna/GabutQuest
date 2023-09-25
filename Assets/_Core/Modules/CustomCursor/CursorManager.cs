using UnityEngine;

namespace CustomCursor
{
    public class CursorManager : MonoBehaviour
    {
        [SerializeField] private Texture2D cursorTexture;
        [SerializeField] private Vector2 hotspot = Vector2.zero;
        [SerializeField] private bool hideCursor;
        [SerializeField] private bool lockCursor;

        public bool IsForceLocked { get; set; }

        private CursorInput _cursorInput;

        private void Start()
        {
            // Init(cursorTexture);
        }

        public void Init(Texture2D newCursorTexture, float size = 1f)
        {
            _cursorInput = new CursorInput();
            // var newTexture = TextureScaler.scaled(newCursorTexture, (int)(newCursorTexture.width * size), (int)(newCursorTexture.height * size));
            // newCursorTexture.Reinitialize((int)(newCursorTexture.width * size), (int)(newCursorTexture.height * size));
            SetCursor(newCursorTexture);
            _cursorInput.Cursor.Unlock.performed += _ => LockCursor(false);
            _cursorInput.Cursor.Unlock.canceled += _ => LockCursor(true);
        }

        private void LockCursor(bool isLock)
        {
            if (IsForceLocked) return;
            Cursor.lockState = isLock ? CursorLockMode.Locked : CursorLockMode.None;
        }

        public void SetCursor(Texture2D newCursorTexture, bool isCenter = false)
        {
            if (isCenter)
            {
                hotspot = new Vector2(newCursorTexture.width / 2f, newCursorTexture.height / 2f);
            }

            cursorTexture = newCursorTexture;
            Cursor.SetCursor(cursorTexture, hotspot, CursorMode.ForceSoftware);
        }
    }
}