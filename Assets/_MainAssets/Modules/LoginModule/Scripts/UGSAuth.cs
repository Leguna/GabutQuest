using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace LoginModule
{
    public class UgsAuth : MonoBehaviour
    {
        [SerializeField] private Button _signInAnonButton;
        [SerializeField] private Button _signInGoogleButton;
        [SerializeField] private TMP_Text _errorText;

        [SerializeField] private GameObject _signinView;

        public UnityEvent onSignInSuccess;

        private async void Start()
        {
            await Init();
            InitializePlayGamesLogin();
            SetListener();
        }

        public Task Init()
        {
            _errorText.text = "";
            try
            {
                // await UnityServices.InitializeAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return Task.CompletedTask;
        }

        private void SetListener()
        {
            _signInAnonButton.onClick.AddListener(SignInAnonymously);
            _signInGoogleButton.onClick.AddListener(LoginGoogle);
            onSignInSuccess.AddListener(() => _signinView.SetActive(false));
        }

        private void InitializePlayGamesLogin()
        {
            // var config = new PlayGamesClientConfiguration.Builder()
            //     .RequestIdToken()
            //     .Build();
            //
            // PlayGamesPlatform.InitializeInstance(config);
            // PlayGamesPlatform.DebugLogEnabled = true;
            // PlayGamesPlatform.Activate();
        }

        private void LoginGoogle()
        {
            Social.localUser.Authenticate(OnGoogleLogin);
        }

        private void OnGoogleLogin(bool success)
        {
            // _errorText.text = "";
            // if (success)
            // {
            //     // Call Unity Authentication SDK to sign in or link with Google.
            //     Debug.Log("Login with Google done. IdToken: " + ((PlayGamesLocalUser)Social.localUser).GetIdToken());
            //     _errorText.text = "Login with Google done. IdToken: " +
            //                       ((PlayGamesLocalUser)Social.localUser).GetIdToken();
            //     _errorText.color = Color.green;
            //     onSignInSuccess?.Invoke();
            // }
            // else
            // {
            //     Debug.Log("Unsuccessful login");
            //     _errorText.text = "Unsuccessful login";
            //     _errorText.color = Color.red;
            // }
        }

        private void SignInAnonymously()
        {
            // try
            // {
            //     await AuthenticationService.Instance.SignInAnonymouslyAsync();
            //     var playerId = AuthenticationService.Instance.PlayerId;
            //     var playerName = AuthenticationService.Instance.PlayerName;
            //     Debug.Log($"Signed in as {playerName} with id {playerId}");
            //     _errorText.text = $"Signed in as {playerName} with id {playerId}";
            //     _errorText.color = Color.green;
            //     onSignInSuccess?.Invoke();
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e);
            //     _errorText.text = e.Message;
            //     _errorText.color = Color.red;
            // }
        }

        private void Logout()
        {
            // try
            // {
            //     AuthenticationService.Instance.SignOut();
            //     _signinView.SetActive(true);
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e);
            //     _errorText.text = e.Message;
            // }
        }
    }
}