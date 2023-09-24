using Firebase.Auth;
using LoginModule;
using UnityEngine;

public class TestLoginScene : MonoBehaviour
{
    private void Start()
    {
        var loginController = FindObjectOfType<LoginController>();
        loginController.Init(StartGame, OnSignedIn);
    }

    private void StartGame()
    {
    }

    private void OnSignedIn(FirebaseUser obj)
    {
    }
}