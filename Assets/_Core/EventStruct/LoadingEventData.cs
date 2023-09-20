using System.Threading.Tasks;

namespace EventStruct
{
    public struct LoadingEventData
    {
        public Task Task;
        public string Message;
    }
}