using DamageModule;
using Spawn;
using SpawnPoint;
using UnityEngine;

public class FlowGame : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    private DamageSystem _damageSystem;

    private GameState _gameState;
    private bool _initiated;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        if (_initiated) return;
        _damageSystem = FindObjectOfType<DamageSystem>();
        _damageSystem.Init();
        spawner.Init(_damageSystem);
        _initiated = true;

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