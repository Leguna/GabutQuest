using System.Threading.Tasks;
using Constant;
using CustomCursor;
using Cysharp.Threading.Tasks;
using EventStruct;
using Firebase.Auth;
using LoadingModule;
using LoginModule;
using Player;
using SaveLoad;
using Service.API;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using Utilities;

public class Runner : SingletonMonoBehaviour<Runner>
{
    private LoadingManager LoadingManager { get; set; }
    public LoginController LoginController { get; private set; }
    private CursorManager _cursor;

    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private ParticleSystem particleCursor;

    private BaseAPIService _baseApiService;

    private async void Start()
    {
        await Init();
    }

    private async Task Init()
    {
        // Init API Service
        _baseApiService = new BaseAPIService(GameConstant.BaseUrl, "");

        // Set Cursor
        _cursor = gameObject.AddComponent<CursorManager>();
        _cursor.Init(cursorTexture);
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

    private async void OnSignedIn(FirebaseUser obj)
    {
        var token = await obj.TokenAsync(false);
        _baseApiService.SetToken(token);
    }

    private void StartGame()
    {
        LoadingManager.AddTask(new LoadingEventData<UnityWebRequest>(
            _baseApiService.RequestData("players/stats/"),
            LoadingManager.LoadingType.FullScreen, OnDataPlayerGet
        ));
    }

    private async void OnDataPlayerGet(UnityWebRequest requestData)
    {
        var playerStats = ScriptableObject.CreateInstance<PlayerBaseData>();
        playerStats.RestoreState(requestData.downloadHandler.text);
        SaveLoadSystem.Save(playerStats);

        await LoadingManager.UnloadScene(SceneNameConstant.SceneName.LoginScreen);
        await LoadingManager.LoadScene(SceneNameConstant.SceneName.GameScreen);
        await LoadingManager.LoadScene(SceneNameConstant.SceneName.DamageSystemScene);

        var gameFlow = FindObjectOfType<FlowGame>();
        gameFlow.Init();
    }
}