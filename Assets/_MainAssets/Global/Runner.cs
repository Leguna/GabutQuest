using System.Threading.Tasks;
using Actor;
using Constant;
using CustomCursor;
using Cysharp.Threading.Tasks;
using EventStruct;
using Firebase.Auth;
using LoadingModule;
using LoginModule;
using SaveLoad;
using Service.API;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

public class Runner : LifetimeScope
{
    private LoadingManager LoadingManager { get; set; }
    private CursorSystem _cursor;
    [SerializeField] private CursorComponent cursorComponent;
    private BaseAPIService _baseApiService;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<BaseAPIService>(Lifetime.Singleton);
        builder.Register<CursorSystem>(Lifetime.Singleton);
        builder.RegisterComponent(cursorComponent);
        builder.RegisterBuildCallback(InjectCallback);
    }

    private async void InjectCallback(IObjectResolver container)
    {
        _baseApiService = container.Resolve<BaseAPIService>();
        _cursor = container.Resolve<CursorSystem>();
        await Init();
    }


    private async Task Init()
    {
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
        // _cursor.SetIsForceLocked(true);
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