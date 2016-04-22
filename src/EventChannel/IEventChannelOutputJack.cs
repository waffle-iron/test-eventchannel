using System;

namespace EventChannel
{
    public interface IEventChannelOutputJack<T> where T : class
    {
        string OutputName { get; set; }
        Predicate<T> EventFilter { get; set; }
        Action<T> EventHandler { get; set; }
    }
}
