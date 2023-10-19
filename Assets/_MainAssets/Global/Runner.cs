using System.Threading.Tasks;
using Constant;
using CustomCursor;
using Cysharp.Threading.Tasks;
using Firebase.Auth;
using LoadingModule;
using LoginModule;
using Service.API;
using Service.API.Models;
using UnityEngine;
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

    private async void StartGame()
    {
        var requestData = await _baseApiService.RequestData("players/stats/");
        var playerStats = JsonUtility.FromJson<PlayerStatsRequest>(requestData.downloadHandler.text);
        Debug.Log(playerStats);
        // TODO: Save/Load System
        await LoadingManager.UnloadScene(SceneNameConstant.SceneName.LoginScreen);
        await LoadingManager.LoadScene(SceneNameConstant.SceneName.GameScreen);
        await LoadingManager.LoadScene(SceneNameConstant.SceneName.DamageSystemScene);

        var gameFlow = FindObjectOfType<FlowGame>();
        var damageSystem = FindObjectOfType<DamageSystem.DamageSystem>();

        damageSystem.Init();
        gameFlow.Init();
    }
}