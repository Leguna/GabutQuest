namespace Service.API
{
    public interface IEventTrigger<in T>
    {
        void TriggerEvent(string eventName, T data);
    }
}