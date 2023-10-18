using System.Threading.Tasks;
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

        public Task<UnityWebRequestAsyncOperation> RequestData<T>(string path)
        {
            var requestUrl = $"{baseUrl}/{path}";
            var request = UnityWebRequest.Get($"{requestUrl}");
            request.SetRequestHeader("Authorization", $"Bearer {userToken}");
            request.timeout = 10;

            return Task.FromResult(request.SendWebRequest());
        }
    }
}