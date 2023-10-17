using System.Threading.Tasks;
using UnityEngine.Networking;

namespace Service.API
{
    public class BaseAPIService
    {
        private readonly string baseUrl;
        private readonly string userToken;

        private BaseAPIService(string url, string token)
        {
            baseUrl = url ?? "";
            userToken = token ?? "";
        }

        public Task<UnityWebRequestAsyncOperation> RequestData<T>(string path)
        {
            var requestUrl = $"{baseUrl}/api/v1/{path}";
            var request = UnityWebRequest.Get($"{requestUrl}");
            request.SetRequestHeader("Authorization", $"Bearer {userToken}");
            request.timeout = 10;

            return Task.FromResult(request.SendWebRequest());
        }
    }
}