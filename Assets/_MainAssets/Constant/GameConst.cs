namespace Constant
{
    public static class GameConst
    {
        public const int SplashScreenDelayInSecond = 2;
        public const float LoadingScreenDelay = 2f;

        // Object name
        public const string PlayerObjectName = "Player";
        public const string PlayerCameraObjectName = "PlayerCamera";
        public const string CameraBound = "CameraBound";

        // Tag
        public const string BoundingTag = "Bounding";

        // Endpoint URL and Path API
        public const string BaseUrl = "https://us-central1-gabutquest.cloudfunctions.net/api/v1/";
        public const string BaseUrlDev = "http://127.0.0.1:5001/gabutquest/us-central1/api/v1/";
    }
}