using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities.ViewComponent;

namespace LoginModule
{
    public sealed class SignUpView : ViewCore
    {
        [SerializeField] private TMP_InputField inputFieldEmail;
        [SerializeField] private TMP_InputField inputFieldPassword;
        [SerializeField] private TMP_InputField inputFieldPasswordConfirm;
        [SerializeField] private Button signUpButton;
        [SerializeField] private Button alreadyHaveAccountText;
        [SerializeField] private TMP_Text signUpErrorText;

        public delegate void SignUpDelegate(string email, string password);

        public event SignUpDelegate SignUp;
        public event Action AlreadyHaveAccount;

        public void Init()
        {
            signUpErrorText.text = "";
            alreadyHaveAccountText.onClick.AddListener(() => { AlreadyHaveAccount?.Invoke(); });
        }

        public void SetListener(SignUpDelegate signUp, Action alreadyHaveAccount)
        {
            SignUp += signUp;
            AlreadyHaveAccount += alreadyHaveAccount;
        }

        private void OnSignUp()
        {
            var email = inputFieldEmail.text;
            var password = inputFieldPassword.text;
            signUpErrorText.gameObject.SetActive(true);
            
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                signUpErrorText.text = "Email or password is empty";
                return;
            }

            if (password != inputFieldPasswordConfirm.text)
            {
                signUpErrorText.text = "Password and confirm password is not match";
                return;
            }

            if (password.Length < 6)
            {
                signUpErrorText.text = "Password must be at least 6 characters";
                return;
            }
            
            signUpErrorText.gameObject.SetActive(false);
            signUpErrorText.text = "";
            SignUp?.Invoke(email, password);
        }
    }
}