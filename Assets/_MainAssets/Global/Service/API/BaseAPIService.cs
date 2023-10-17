using System.Threading.Tasks;
using UnityEngine.Networking;

namespace Service.API
{
    public class BaseAPIService
    {
        private string baseUrl;
        private string userToken;

        protected void Init(string url, string token)
        {
            baseUrl = url ?? "";
            userToken = token ?? "";
        }

        public Task<UnityWebRequestAsyncOperation> RequestData<T>(string url)
        {
            UnityWebRequest request = UnityWebRequest.Get($"{baseUrl}/api/v1/");
            request.SetRequestHeader("Authorization", $"Bearer {userToken}");
            request.timeout = 10;

            return Task.FromResult(request.SendWebRequest());
        }

        public string TrimUTF8Bom(string value)
        {
            value = value.Trim('\uFEFF', '\u200B');
            return value;
        }
    }
}