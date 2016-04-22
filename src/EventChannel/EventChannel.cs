using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventChannel
{
    public sealed class EventChannel<T> : IEventChannelInputJack<T>, IEventChannelOutputJack<T> where T : class
    {
        private IList<Task> _tasks = new List<Task>();

        public string InputName { get; set; }
        public string OutputName { get; set; }
        public Predicate<T> EventFilter { get; set; }
        public Action<T> EventHandler { get; set; }

        public void Take(T eventArgs)
        {
            if (EventFilter(eventArgs))
            {
                _tasks.Add(Task.Run(() => EventHandler(eventArgs)));
            }
        }

        public void WaitAll(TimeSpan timeout)
        {
            Task.WaitAll(_tasks.ToArray(), timeout);
        }
    }
}