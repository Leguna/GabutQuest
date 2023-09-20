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
                SignInWithEmail?.Invoke(emailInputField.text, passwordInputField.text);
            });
        }

        public void SetErrorText(string errorText)
        {
            signInErrorText.text = errorText;
        }

        public override void Show()
        {
            Init();
            base.Show();
        }

        public void EnableSignInButton(bool enable)
        {
            signInButton.interactable = enable;
        }

        private void OnSignInWithEmail(string email, string password)
        {
            SignInWithEmail?.Invoke(email, password);
        }

        private void OnSignInAnonymously()
        {
            SignInAnonymously?.Invoke();
        }

        private void OnSignInWithGoogle()
        {
            SignInWithGoogle?.Invoke();
        }

        private void OnDontHaveAccount()
        {
            DontHaveAccount?.Invoke();
        }
    }
}