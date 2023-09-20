using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public UnityEvent onConfirm;
        public UnityEvent onBack;

        private EventSystem _eventSystem;
        private UIInputAction mInputAction;

        private void Awake()
        {
            mInputAction = new UIInputAction();
            mInputAction.UI.Confirm.performed += _ => onConfirm?.Invoke();
            mInputAction.UI.Back.performed += _ => onBack?.Invoke();
            mInputAction.UI.NextInputSelected.performed += _ => NextUI();
            mInputAction.UI.PreviousInputSelected.performed += _ => PrevUI();
        }

        private void OnEnable()
        {
            mInputAction.Enable();
        }

        private void OnDisable()
        {
            mInputAction.Disable();
        }

        private void NextUI()
        {
            _eventSystem = EventSystem.current;
            if (_eventSystem.currentSelectedGameObject == null) return;
            if (_eventSystem.currentSelectedGameObject.GetComponent<Selectable>() == null) return;
            _eventSystem.SetSelectedGameObject(_eventSystem.currentSelectedGameObject.GetComponent<Selectable>()
                .FindSelectableOnDown().gameObject);
        }

        private void PrevUI()
        {
            _eventSystem = EventSystem.current;
            if (_eventSystem.currentSelectedGameObject == null) return;
            if (_eventSystem.currentSelectedGameObject.GetComponent<Selectable>() == null) return;
            _eventSystem.SetSelectedGameObject(_eventSystem.currentSelectedGameObject.GetComponent<Selectable>()
                .FindSelectableOnUp().gameObject);
        }
    }
}