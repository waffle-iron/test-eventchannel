using System;
using System.Collections.Generic;

namespace EventChannel
{
    public sealed class EventSource<T> : IEventSourceBindingJack<T> where T : class
    {
        private IList<IEventChannelInputJack<T>> _bindings = new List<IEventChannelInputJack<T>>();

        public string InputName { get; private set; }
        public IEnumerable<IEventChannelInputJack<T>> Bindings { get { return _bindings; } }

        public EventSource(string inputName)
        {
            if (string.IsNullOrWhiteSpace(inputName))
            {
                throw new ArgumentException("inputName must be not white space string.");
            }

            InputName = inputName;
        }

        public void Raise(T args)
        {
            foreach (var binding in Bindings)
            {
                binding.Take(args);
            }
        }

        public void Bind(IEventChannelInputJack<T> binding)
        {
            if (!_bindings.Contains(binding))
            {
                _bindings.Add(binding);
                binding.InputName = InputName;
            }
        }

        public void Unbind(IEventChannelInputJack<T> binding)
        {
            if (_bindings.Contains(binding))
            {
                _bindings.Remove(binding);
            }
        }
    }
}
