using UnityEngine;
using UnityEngine.InputSystem;

namespace CustomCursor
{
    public class CursorManager : MonoBehaviour
    {
        private Texture2D cursorTexture;
        private Vector2 hotspot = Vector2.zero;
        private ParticleSystem particleCursor;

        private bool isClick;
        private bool isVisible;

        private bool IsForceLocked { get; set; }

        public void SetIsForceLocked(bool value)
        {
            IsForceLocked = value;
            LockCursor(value);
        }

        private CursorInput _cursorInput;

        public void Init(Texture2D newCursorTexture, ParticleSystem newParticleSystem, float size = 1f)
        {
            _cursorInput = new CursorInput();
            _cursorInput.Enable();
            SetVisible(isVisible);
            SetCursor(newCursorTexture);
            particleCursor = newParticleSystem;
            _cursorInput.Cursor.Unlock.performed += _ => LockCursor(false);
            _cursorInput.Cursor.Unlock.canceled += _ => LockCursor(true);
            _cursorInput.Cursor.Click.started += OnClick;
            _cursorInput.Cursor.Click.canceled += OnRelease;
        }

        private void FixedUpdate()
        {
            if (!isClick) return;
            if (!isVisible) return;

            Debug.Log("Update");
            if (Camera.main == null) return;

            var mousePosition = Mouse.current.position.ReadValue();
            var worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            worldPosition.z = 0f;
            particleCursor.transform.position = worldPosition;
        }

        private void LockCursor(bool isLock)
        {
            if (!IsForceLocked) return;

            if (isLock) particleCursor.Stop();
            SetVisible(!isLock);
            Cursor.lockState = isLock ? CursorLockMode.Locked : CursorLockMode.None;
        }

        private void SetCursor(Texture2D newCursorTexture, bool isCenter = false)
        {
            if (isCenter)
            {
                hotspot = new Vector2(newCursorTexture.width / 2f, newCursorTexture.height / 2f);
            }

            cursorTexture = newCursorTexture;
            Cursor.SetCursor(cursorTexture, hotspot, CursorMode.ForceSoftware);
        }

        public void SpawnParticleCursor(ParticleSystem cursorParticle)
        {
            particleCursor = cursorParticle;
            particleCursor.Stop();
        }

        public void OnClick(InputAction.CallbackContext callbackContext)
        {
            isClick = true;
            if (!isVisible) return;
            if (particleCursor.isPlaying) return;
            particleCursor.Play();
        }

        private void OnRelease(InputAction.CallbackContext obj)
        {
            isClick = false;
            particleCursor.Stop();
        }

        public void SetVisible(bool newIsVisible)
        {
            isVisible = newIsVisible;
            Cursor.visible = newIsVisible;
        }

        private void OnDisable()
        {
            _cursorInput.Disable();
        }
    }
}