using System;

namespace EventChannel
{
    public sealed class PhysicalReader
    {
        public string ReaderName { get; private set; }
        public EventSource<TagReadData> TagReadEventSource { get; private set; }

        public PhysicalReader(string readerName)
        {
            if (string.IsNullOrWhiteSpace(readerName))
            {
                throw new ArgumentException(nameof(readerName));
            }

            ReaderName = readerName;
            TagReadEventSource = new EventSource<TagReadData>(ReaderName);
        }

        public void SimulateTagRead(TagReadData data)
        {
            TagReadEventSource.Raise(data);
        }
    }
}
