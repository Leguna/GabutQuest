using System;
using System.Threading.Tasks;
using Constant;
using Cysharp.Threading.Tasks;
using ToastModal;
using UnityEngine.Networking;
using VContainer;

namespace Service.API
{
    public class BaseAPIService
    {
        private readonly string baseUrl;
        private string userToken;

        [Inject]
        public BaseAPIService()
        {
#if UNITY_EDITOR
            baseUrl = GameConst.BaseUrlDev;
#else
            baseUrl = GameConst.BaseUrl;
#endif
        }

        public void SetToken(string token)
        {
            userToken = token;
        }

        public Task<UnityWebRequest> RequestData(string path)
        {
            try
            {
                var requestUrl = $"{baseUrl}{path}";
                var request = UnityWebRequest.Get($"{requestUrl}");
                request.SetRequestHeader("Authorization", $"Bearer {userToken}");
                request.timeout = 10;
                var uniTask = request.SendWebRequest().ToUniTask();
                return uniTask.AsTask();
            }
            catch (Exception)
            {
                ToastSystem.Show("Failed to connect to server");
            }

            return null;
        }
    }
}