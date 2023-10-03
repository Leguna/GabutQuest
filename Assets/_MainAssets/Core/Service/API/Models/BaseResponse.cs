using System;
using System.Collections.Generic;
using UnityEngine;

namespace Service.API.Models
{
    [Serializable]
    public class BaseResponse<T>
    {
        public bool IsSuccess;
        public string Message;
        public int StatusCode;
        public Dictionary<string, string> Errors;

        public bool IsError => !IsSuccess;

        public BaseResponse()
        {
            IsSuccess = false;
            Message = "";
            StatusCode = 0;
            Errors = new Dictionary<string, string>();
        }

        public BaseResponse(bool isSuccess, string message, int statusCode, Dictionary<string, string> errors)
        {
            IsSuccess = isSuccess;
            Message = message;
            StatusCode = statusCode;
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