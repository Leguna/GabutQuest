using Cinemachine;
using SpawnPoint;
using UnityEngine;

public class FlowGame : MonoBehaviour
{
    [SerializeField] private Spawner spawner;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        var playerSystem = spawner.Init();
        playerSystem.Init();
    }
}