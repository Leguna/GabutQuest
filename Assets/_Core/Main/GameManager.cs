using System.Threading.Tasks;
using Constant;
using Cysharp.Threading.Tasks;
using EventStruct;
using Firebase.Auth;
using LoadingModule;
using LoginModule;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

namespace Main
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        public LoadingManager LoadingManager { get; private set; }
        public LoginController LoginController { get; private set; }

        private async void Start()
        {
            await Init();
        }

        private async Task Init()
        {
            await SceneManager.LoadSceneAsync(SceneNameConstant.Loading, LoadSceneMode.Additive);
            var task = SceneManager.LoadSceneAsync(SceneNameConstant.Splash, LoadSceneMode.Additive).ToUniTask()
                .AsTask();
            LoadingManager = FindObjectOfType<LoadingManager>();
            LoadingManager.AddTask(new LoadingEventData
            {
                Task = task,
                Message = "Loading Splash Screen"
            });

            await Task.Delay(GameConstant.SplashScreenDelayInSecond * 2000);

            await SceneManager.LoadSceneAsync(SceneNameConstant.Login, LoadSceneMode.Additive);
            await SceneManager.UnloadSceneAsync(SceneNameConstant.Splash);

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
            Debug.Log("StartGame");
            await SceneManager.LoadSceneAsync(SceneNameConstant.Game, LoadSceneMode.Additive);
            await SceneManager.UnloadSceneAsync(SceneNameConstant.Login);
            Debug.Log("StartGame: UnloadSceneAsync");
            
        }
    }
}