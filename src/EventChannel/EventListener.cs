using System;

namespace EventChannel
{
    public sealed class EventListener<T> where T : class
    {
        public string OutputName { get; private set; }
        public Action<T> EventHandler { get; private set; }
        public Predicate<T> EventFilter { get; private set; }

        public EventListener(string outputName, Action<T> eventHandler, Predicate<T> eventFilter)
        {
            if (string.IsNullOrWhiteSpace(outputName) || eventHandler == null || eventFilter == null)
            {
                throw new ArgumentException("Check outputName, eventHandler, and eventFilter arguments.");
            }

            OutputName = outputName;
            EventHandler = eventHandler;
            EventFilter = eventFilter;
        }

        public void Bind(IEventChannelOutputJack<T> binding)
        {
            if (binding == null)
            {
                throw new ArgumentNullException(nameof(binding));
            }

            binding.EventFilter = EventFilter;
            binding.EventHandler = EventHandler;
            binding.OutputName = OutputName;
        }
    }
}
