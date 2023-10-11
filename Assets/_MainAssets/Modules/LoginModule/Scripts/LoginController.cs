using System;
using System.Threading.Tasks;
using EventStruct;
using Firebase;
using Firebase.Auth;
using LoadingModule;
using UnityEngine;
using UnityEngine.Events;
using Utilities;

namespace LoginModule
{
    public class LoginController : MonoBehaviour
    {
        public SignUpView signUpView;
        public LoginView loginView;
        public LoggedInView loggedInView;

        public UnityEvent<string> onSignUpSuccess;
        public UnityEvent<FirebaseUser> onSignInSuccess;
        private FirebaseAuth _auth;

        private string _idToken;
        private FirebaseUser _user;

        private Action _startGame;
        private LoginViewState _state = LoginViewState.Login;

        public void Init(Action startGame, Action<FirebaseUser> onSignedIn)
        {
            _startGame = startGame;
            onSignInSuccess.AddListener(onSignedIn.Invoke);

            InitFirebase();
            InitView();
        }

        private void InitView()
        {
            loginView.Init();
            loginView.SetListener(SignInWithEmail,
                SignInAnonymously,
                () => ChangeViewState(LoginViewState.SignUp)
            );

            signUpView.Init();
            signUpView.SetListener(SignUp,
                () => ChangeViewState(LoginViewState.Login)
            );

            loggedInView.SetListener(LogOut, _startGame);
        }

        private void InitFirebase()
        {
            _auth = FirebaseAuth.DefaultInstance;
            _auth.StateChanged += AuthStateChanged;
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(_ => { });
        }

        private void AuthStateChanged(object sender, EventArgs eventArgs)
        {
            if (_auth.CurrentUser == null)
            {
                ChangeViewState(LoginViewState.Login);
                return;
            }

            if (_auth.CurrentUser != _user)
            {
                bool signedIn = _user != _auth.CurrentUser && _auth.CurrentUser != null
                                                           && _auth.CurrentUser.IsValid();
                if (!signedIn && _user != null) Debug.Log("Signed out " + _user.UserId);

                _user = _auth.CurrentUser;
                if (!signedIn) return;
                onSignInSuccess?.Invoke(_user);
                ChangeViewState(LoginViewState.LoggedIn);
                Debug.Log("Signed in " + _auth.CurrentUser.UserId);
            }
        }

        private void SignIn(bool isAnon = false, string email = "", string password = "")
        {
            if (_state == LoginViewState.Waiting) return;
            ChangeViewState(LoginViewState.Waiting);

            Task task = isAnon
                ? _auth.SignInAnonymouslyAsync()
                : _auth.SignInWithEmailAndPasswordAsync(email, password);

            EventManager.TriggerEvent(new LoadingEventData
            {
                Task = task,
                Message = "Signing in...",
                LoadingType = LoadingManager.LoadingType.Overlay
            });
        }

        private void SignInWithEmail(string email, string password)
        {
            SignIn(false, email, password);
        }

        private void SignInAnonymously()
        {
            SignIn(true);
        }

        private void SignUp(string email, string password)
        {
            if (_state == LoginViewState.Waiting) return;
            ChangeViewState(LoginViewState.Waiting);

            _auth.CreateUserWithEmailAndPasswordAsync(email, password);
        }

        private void LogOut()
        {
            try
            {
                _user = null;
                _auth.SignOut();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void ChangeViewState(LoginViewState state)
        {
            _state = state;
            if (state == LoginViewState.Waiting) return;
            loginView.Hide();
            signUpView.Hide();
            loggedInView.Hide();
            switch (state)
            {
                case LoginViewState.Login:
                    loginView.Show();
                    break;
                case LoginViewState.SignUp:
                    signUpView.Show();
                    break;
                case LoginViewState.LoggedIn:
                    loggedInView.Show();
                    break;
                default:
                case LoginViewState.None:
                    break;
            }
        }

        private void OnDestroy()
        {
            _auth.StateChanged -= AuthStateChanged;
            _auth = null;
        }
    }
}