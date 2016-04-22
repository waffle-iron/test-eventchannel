namespace EventChannel
{
    public interface IEventSourceBindingJack<T> where T : class
    {
        void Bind(IEventChannelInputJack<T> binding);
        void Unbind(IEventChannelInputJack<T> binding);
    }
}
