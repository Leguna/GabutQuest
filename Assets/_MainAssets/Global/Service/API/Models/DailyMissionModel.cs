using System;

namespace Service.API.Models
{
    [Serializable]
    public class DailyMissionModel : BaseResponse<DailyMissionModel>
    {
        public string ID;
        public string Name;
        public string Description;
        public int Reward;
        public int Progress;
        public int Target;
        public bool IsClaimed;
    }

    [Serializable]
    public class DailyMissionResponse : BaseResponse<DailyMissionResponse>
    {
        public DailyMissionModel[] Data;
    }

    [Serializable]
    public class DailyMissionClaimRequest : BaseResponse<DailyMissionClaimRequest>
    {
        public string ID;
    }

    [Serializable]
    public class DailyLoginResponse : BaseResponse<DailyLoginResponse>
    {
        public int Day;
        public int Reward;
    }

    [Serializable]
    public class DailyLoginClaimRequest : BaseResponse<DailyLoginClaimRequest>
    {
        public int Day;
    }
}