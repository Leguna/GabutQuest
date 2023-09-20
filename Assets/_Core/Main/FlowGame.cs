using UnityEngine;

namespace Main
{
    public class FlowGame : MonoBehaviour
    {
        public enum GameState
        {
            Splash,
            Loading,
            MainMenu,
            InGame,
            Cinematic,
            Pause,
            None
        }
    }
}