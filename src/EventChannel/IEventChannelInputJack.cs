using System;

namespace EventChannel
{
    public interface IEventChannelInputJack<T> where T : class
    {
        string InputName { get; set; }
        void Take(T eventArgs);
    }
}
