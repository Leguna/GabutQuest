using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

namespace Service.API
{
    public class BaseAPIService
    {
        private readonly string baseUrl;
        private string userToken;

        public BaseAPIService(string url, string token)
        {
            baseUrl = url ?? "";
            userToken = token ?? "";
        }

        public void SetToken(string token)
        {
            userToken = token;
        }

        public Task<UnityWebRequest> RequestData(string path)
        {
            var requestUrl = $"{baseUrl}{path}";
            var request = UnityWebRequest.Get($"{requestUrl}");
            request.SetRequestHeader("Authorization", $"Bearer {userToken}");
            request.timeout = 10;
            var uniTask = request.SendWebRequest().ToUniTask();
            return uniTask.AsTask();
        }
    }
}