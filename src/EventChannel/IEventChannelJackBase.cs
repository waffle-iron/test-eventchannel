namespace EventChannel
{
    public interface IEventChannelJackBase<T> where T : class
    {
        bool IsCancelled { get; set; }
    }
}
