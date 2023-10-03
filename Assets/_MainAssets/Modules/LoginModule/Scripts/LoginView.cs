using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities.ViewComponent;

namespace LoginModule
{
    public sealed class LoginView : ViewCore
    {
        public delegate void DontHaveAccountDelegate();

        public delegate void SignInAnonymouslyDelegate();

        public delegate void SignInWithEmailDelegate(string email, string password);

        public delegate void SignInWithGoogleDelegate();

        [SerializeField] private TMP_InputField emailInputField;
        [SerializeField] private TMP_InputField passwordInputField;
        [SerializeField] private Button signInButton;
        [SerializeField] private TMP_Text signInErrorText;
        [SerializeField] private Button dontHaveAccountText;
        [SerializeField] private Button anonymousSignInButton;

        private LoginViewState _loginViewState;

        private event SignInWithEmailDelegate SignInWithEmail;

        private event SignInAnonymouslyDelegate SignInAnonymously;

        private event SignInWithGoogleDelegate SignInWithGoogle;

        private event DontHaveAccountDelegate DontHaveAccount;

        public void SetListener(SignInWithEmailDelegate signInWithEmailDelegate,
            SignInAnonymouslyDelegate signInAnonymouslyDelegate = null,
            DontHaveAccountDelegate dontHaveAccountDelegate = null,
            SignInWithGoogleDelegate signInWithGoogleDelegate = null)
        {
            SignInWithEmail += signInWithEmailDelegate;
            SignInAnonymously += signInAnonymouslyDelegate;
            DontHaveAccount += dontHaveAccountDelegate;
            SignInWithGoogle += signInWithGoogleDelegate;
        }

        public void Init()
        {
            emailInputField.text = "gabut@gmail.com";
            passwordInputField.text = "123123";
            signInErrorText.text = "";
            signInErrorText.gameObject.SetActive(false);
            dontHaveAccountText.onClick.AddListener(() => { DontHaveAccount?.Invoke(); });
            anonymousSignInButton.onClick.AddListener(() => { SignInAnonymously?.Invoke(); });
            signInButton.onClick.AddListener(() =>
            {
                if (!ValidateEmail(emailInputField.text)) return;
                SignInWithEmail?.Invoke(emailInputField.text, passwordInputField.text);
            });
        }

        private void SetErrorText(string errorText)
        {
            if (string.IsNullOrEmpty(errorText))
            {
                signInErrorText.gameObject.SetActive(false);
                return;
            }

            signInErrorText.gameObject.SetActive(true);
            signInErrorText.text = errorText;
        }

        public override void Show()
        {
            Init();
            base.Show();
        }

        private bool ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                SetErrorText("Email cannot be empty");
                return false;
            }

            if (email.Contains("@")) return true;
            SetErrorText("Email must contain @");
            return false;
        }

        private void OnSignInWithGoogle()
        {
            SignInWithGoogle?.Invoke();
        }
    }
}