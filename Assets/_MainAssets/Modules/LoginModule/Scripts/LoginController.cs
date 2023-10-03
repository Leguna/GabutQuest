using System;
using EventStruct;
using Firebase;
using Firebase.Auth;
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
        private LoginViewState _state = LoginViewState.None;

        public void Init(Action startGame, Action<FirebaseUser> onSignedIn)
        {
            _startGame = startGame;
            onSignInSuccess.AddListener(onSignedIn.Invoke);

            InitView();
            InitFirebase();
        }

        private void InitView()
        {
            ChangeViewState(LoginViewState.None);
            loginView.Init();
            loginView.SetListener(SignInWithEmail,
                SignInAnonymously,
                () => ChangeViewState(LoginViewState.SignUp)
            );
            onSignInSuccess.AddListener(onSignInSuccess.Invoke);

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
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(_ =>
            {
                // var dependencyStatus = task.Result;
                // if (dependencyStatus == DependencyStatus.Available)
                //     // _app = FirebaseApp.DefaultInstance;
                //     Debug.Log("FirebaseApp.DefaultInstance");
                // else
                //     Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}");
            });
        }

        private void AuthStateChanged(object sender, EventArgs eventArgs)
        {
            if (_auth.CurrentUser == null)
            {
                ChangeViewState(LoginViewState.Login);
            }
            else if (_auth.CurrentUser != _user)
            {
                var signedIn = _user != _auth.CurrentUser
                               && _auth.CurrentUser != null
                               && _auth.CurrentUser.IsValid();

                _user = _auth.CurrentUser;
                if (!signedIn) return;
                ChangeViewState(LoginViewState.LoggedIn);
            }
        }

        private void SignInWithEmail(string email, string password)
        {
            if (_state == LoginViewState.Waiting) return;
            ChangeViewState(LoginViewState.Waiting);

            var task = _auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
            {
                if (task.IsCanceled)
                {
                    Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                    return;
                }

                if (task.IsFaulted)
                {
                    Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                    if (task.Exception is { } ex)
                    {
                        FirebaseException fbEx = null;
                        foreach (var e in ex.InnerExceptions)
                        {
                            fbEx = e as FirebaseException;
                            if (fbEx != null)
                                break;
                        }

                        if (fbEx != null) Debug.LogError("Encountered a FirebaseException:" + fbEx.Message);
                    }

                    return;
                }

                _user = task.Result.User;
            });
            EventManager.TriggerEvent(new LoadingEventData
            {
                Task = task,
                Message = "Signing in..."
            });
        }

        private void SignInAnonymously()
        {
            _auth.SignInAnonymouslyAsync().ContinueWith(task =>
            {
                if (task.IsCanceled)
                {
                    Debug.LogError("SignInAnonymouslyAsync was canceled.");
                    return;
                }

                if (task.IsFaulted)
                {
                    Debug.LogError("SignInAnonymouslyAsync encountered an error: " + task.Exception);
                    if (task.Exception is { } ex)
                    {
                        FirebaseException fbEx = null;
                        foreach (var e in ex.InnerExceptions)
                        {
                            fbEx = e as FirebaseException;
                            if (fbEx != null)
                                break;
                        }

                        if (fbEx != null) Debug.LogError("Encountered a FirebaseException:" + fbEx.Message);
                    }

                    return;
                }

                var newUser = task.Result;
                Debug.LogFormat("User signed in successfully: {0} ({1})", newUser.User.DisplayName,
                    newUser.User.UserId);
                onSignInSuccess?.Invoke(newUser.User);
            });
        }

        private async void SignUp(string email, string password)
        {
            try
            {
                var task = await _auth.CreateUserWithEmailAndPasswordAsync(email, password);
                var newUser = task.User;
                Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                    newUser.DisplayName, newUser.UserId);
                onSignUpSuccess?.Invoke(newUser.UserId);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to create user with {email} and {password}");
                Debug.LogException(e);
            }
        }

        private void LogOut()
        {
            try
            {
                if (_auth.CurrentUser == null) return;
                _user = null;
                _auth.SignOut();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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
                case LoginViewState.None:
                    break;
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
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private void OnDestroy()
        {
            _auth.StateChanged -= AuthStateChanged;
            _auth = null;
        }
    }
}