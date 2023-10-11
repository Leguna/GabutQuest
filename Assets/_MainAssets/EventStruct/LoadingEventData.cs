using System.Threading.Tasks;
using static LoadingModule.LoadingManager;

namespace EventStruct
{
    public struct LoadingEventData
    {
        public Task Task;
        public string Message;
        public LoadingType LoadingType;
    }
}