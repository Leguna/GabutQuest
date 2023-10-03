using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Command.Console
{
    public class ConsoleController : MonoBehaviour
    {
        [SerializeField] private GameObject debugConsoleView;
        [SerializeField] private TMP_InputField debugConsoleInputField;
        [SerializeField] private Transform historyLogView;
        [SerializeField] private TMP_Text debugConsoleText;
        public bool isDebugConsoleEnabled;
        private ConsoleActionInput _debugConsoleActionInput;

        private readonly List<TMP_Text> debugConsoleTexts = new();

        private void OnEnable()
        {
            Init();
            _debugConsoleActionInput.Console.OpenConsole.performed += ToggleDebugConsole;
            debugConsoleInputField.onSubmit.AddListener(OnCommandSubmit);
        }

        private void OnDisable()
        {
            _debugConsoleActionInput.Console.OpenConsole.performed -= ToggleDebugConsole;
            debugConsoleInputField.onSubmit.RemoveListener(OnCommandSubmit);
        }

        private void Init()
        {
            _debugConsoleActionInput = new ConsoleActionInput();
            _debugConsoleActionInput.Enable();
        }

        private void OnCommandSubmit(string command)
        {
            if (string.IsNullOrEmpty(command)) return;

            var commandPrefix = Instantiate(debugConsoleText, historyLogView);
            commandPrefix.text = command;
            debugConsoleTexts.Add(commandPrefix);
            debugConsoleInputField.text = "";
            debugConsoleInputField.ActivateInputField();
        }

        private void ToggleDebugConsole(InputAction.CallbackContext obj)
        {
            isDebugConsoleEnabled = !isDebugConsoleEnabled;
            debugConsoleView.SetActive(isDebugConsoleEnabled);
        }
    }
}