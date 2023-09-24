using System.Threading.Tasks;
using Constant;
using Cysharp.Threading.Tasks;
using Firebase.Auth;
using LoadingModule;
using LoginModule;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

namespace Main
{
    public class Runner : SingletonMonoBehaviour<Runner>
    {
        public LoadingManager LoadingManager { get; private set; }
        public LoginController LoginController { get; private set; }

        private async void Start()
        {
            await Init();
        }

        private async Task Init()
        {
            await SceneManager.LoadSceneAsync((int)SceneNameConstant.SceneName.LoadingScreen, LoadSceneMode.Additive);
            LoadingManager = FindObjectOfType<LoadingManager>();

            await SceneManager.LoadSceneAsync((int)SceneNameConstant.SceneName.SplashScreen, LoadSceneMode.Additive);
            await Task.Delay(GameConstant.SplashScreenDelayInSecond * 2000);
            await LoadingManager.LoadScene(SceneNameConstant.SceneName.LoginScreen, LoadingManager.LoadingType.None);
            await LoadingManager.UnloadScene(SceneNameConstant.SceneName.SplashScreen, LoadingManager.LoadingType.None);

            // Search for the LoginController in the Login scene
            var loginController = FindObjectOfType<LoginController>();
            loginController.Init(StartGame, OnSignedIn);
        }

        private void OnSignedIn(FirebaseUser obj)
        {
            Debug.Log($"OnSignedIn: {obj}");
        }

        private async void StartGame()
        {
            await LoadingManager.LoadScene(SceneNameConstant.SceneName.GameScreen);
            await LoadingManager.UnloadScene(SceneNameConstant.SceneName.LoginScreen);

            // Search for the GameController in the Game scene
            // TOOD: Add GameController
        }
    }
}