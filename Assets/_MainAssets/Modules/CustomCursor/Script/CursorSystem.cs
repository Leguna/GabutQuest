using System;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

namespace CustomCursor
{
    public class CursorSystem : IDisposable
    {
        private CursorComponent _cursorComponent;
        private CursorInput _cursorInput;
        private Vector2 hotspot = Vector2.zero;
        private bool isVisible;

        private bool IsForceLocked { get; set; }

        public CursorSystem(IObjectResolver container)
        {
            container.Inject(this);
            _cursorComponent.particleCursor = container.Instantiate(_cursorComponent.particleCursor);
        }

        [Inject]
        public void Start(CursorComponent cursorComponent)
        {
            _cursorInput = new CursorInput();
            _cursorInput.Enable();

            _cursorComponent = cursorComponent;
            SetCursor(_cursorComponent.cursorTexture);
            SetVisible(isVisible);

            _cursorInput.Cursor.Unlock.performed += _ => LockCursor(false);
            _cursorInput.Cursor.Unlock.canceled += _ => LockCursor(true);
            _cursorInput.Cursor.Click.performed += OnClick;
        }

        private void SetCursor(Texture2D newCursorTexture, bool isCenter = false)
        {
            if (isCenter)
            {
                hotspot = new Vector2(newCursorTexture.width / 2f, newCursorTexture.height / 2f);
            }

            _cursorComponent.cursorTexture = newCursorTexture;
            Cursor.SetCursor(_cursorComponent.cursorTexture, hotspot, CursorMode.ForceSoftware);
        }

        public void SetVisible(bool newIsVisible)
        {
            isVisible = newIsVisible;
            Cursor.visible = newIsVisible;
        }

        public void SetIsForceLocked(bool value)
        {
            IsForceLocked = value;
            LockCursor(value);
        }

        private void LockCursor(bool isLock)
        {
            if (!IsForceLocked) return;

            if (isLock) _cursorComponent.particleCursor.Stop();
            SetVisible(!isLock);
            Cursor.lockState = isLock ? CursorLockMode.Locked : CursorLockMode.None;
        }

        private void OnClick(InputAction.CallbackContext callbackContext)
        {
            SetVisible(isVisible);
            if (!isVisible) return;
            if (_cursorComponent.IsPlaying) return;
            MoveCursorByMousePosition();
            _cursorComponent.particleCursor.Play();
        }

        private void MoveCursorByMousePosition()
        {
            if (Camera.main == null) return;
            var mousePosition = Mouse.current.position.ReadValue();
            var worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            worldPosition.z = 0f;

            _cursorComponent.particleCursor.transform.position = worldPosition;
        }

        public void Dispose()
        {
            _cursorInput.Disable();
        }
    }
}