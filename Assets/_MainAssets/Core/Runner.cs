using System.Threading.Tasks;
using Constant;
using CustomCursor;
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
        private CursorManager _cursor;

        [SerializeField] private Texture2D cursorTexture;
        [SerializeField] private ParticleSystem particleCursor;

        private async void Start()
        {
            await Init();
        }

        private async Task Init()
        {
            // Set Cursor
            _cursor = gameObject.AddComponent<CursorManager>();
            _cursor.Init(cursorTexture, particleCursor);
            _cursor.SetVisible(false);

            // Load Loading Scene
            await SceneManager.LoadSceneAsync((int)SceneNameConstant.SceneName.LoadingScreen, LoadSceneMode.Additive);
            LoadingManager = FindObjectOfType<LoadingManager>();

            // Load Login Scene
            await SceneManager.LoadSceneAsync((int)SceneNameConstant.SceneName.SplashScreen, LoadSceneMode.Additive);
            await Task.Delay(GameConstant.SplashScreenDelayInSecond * 2000);
            await LoadingManager.LoadScene(SceneNameConstant.SceneName.LoginScreen, LoadingManager.LoadingType.None);
            await LoadingManager.UnloadScene(SceneNameConstant.SceneName.SplashScreen, LoadingManager.LoadingType.None);

            _cursor.SetVisible(true);

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
            _cursor.SetIsForceLocked(true);

            // Search for the GameController in the Game scene
            // TOOD: Add GameController
        }
    }
}