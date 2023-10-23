using SpawnPoint;
using UnityEngine;

public class FlowGame : MonoBehaviour
{
    [SerializeField] private Spawner spawner;

    private GameState _gameState;
    private bool initiated;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        if (initiated) return;
        spawner.Init();
        initiated = true;

        _gameState = GameState.Playing;
        UpdateState();
    }

    private void UpdateState()
    {
        Time.timeScale = _gameState switch
        {
            GameState.Playing => 1,
            GameState.Pause => 0,
            GameState.Cinematic => 1,
            _ => Time.timeScale
        };
    }
}