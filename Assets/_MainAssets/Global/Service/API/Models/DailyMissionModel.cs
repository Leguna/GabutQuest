using System;

namespace Service.API.Models
{
    [Serializable]
    public class DailyMissionModel : BaseResponse<DailyMissionModel>
    {
        public string id;
        public string name;
        public string description;
        public int reward;
        public int progress;
        public int target;
        public bool isClaimed;
    }

    [Serializable]
    public class DailyMissionResponse : BaseResponse<DailyMissionResponse>
    {
        public DailyMissionModel[] data;
    }

    [Serializable]
    public class DailyMissionClaimRequest : BaseResponse<DailyMissionClaimRequest>
    {
        public string id;
    }

    [Serializable]
    public class DailyLoginResponse : BaseResponse<DailyLoginResponse>
    {
        public int day;
        public int reward;
    }

    [Serializable]
    public class DailyLoginClaimRequest : BaseResponse<DailyLoginClaimRequest>
    {
        public int day;
    }
}