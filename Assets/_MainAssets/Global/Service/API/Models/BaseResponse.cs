using System;
using System.Collections.Generic;
using UnityEngine;

namespace Service.API.Models
{
    [Serializable]
    public class BaseResponse<T>
    {
        public bool isSuccess;
        public string message;
        public int statusCode;
        public Dictionary<string, string> Errors;

        public bool IsError => !isSuccess;

        public BaseResponse()
        {
            isSuccess = false;
            message = "";
            statusCode = 0;
            Errors = new Dictionary<string, string>();
        }

        public BaseResponse(bool isSuccess, string message, int statusCode, Dictionary<string, string> errors)
        {
            this.isSuccess = isSuccess;
            this.message = message;
            this.statusCode = statusCode;
            Errors = errors;
        }

        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }

        public static BaseResponse<T> FromJson(string json)
        {
            return JsonUtility.FromJson<BaseResponse<T>>(json);
        }

        public override string ToString()
        {
            return ToJson();
        }
    }
}