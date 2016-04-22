using System;

namespace EventChannel
{
    public sealed class LogicalReader
    {
        public string ReaderName { get; private set; }
        public EventListener<TagReadData> TagReadListener { get; private set; }

        public LogicalReader(string readerName)
        {
            if (string.IsNullOrWhiteSpace(readerName))
            {
                throw new ArgumentException(nameof(readerName));
            }

            ReaderName = readerName;
            TagReadListener = new EventListener<TagReadData>(ReaderName, OnTagRead, new Predicate<TagReadData>(EventFilter));
        }

        private void OnTagRead(TagReadData read)
        {
            Console.WriteLine("{0}: Tag read! Antenna= {1}, Data= {2}", ReaderName, read.Antenna, read.Data);
        }

        private bool EventFilter(TagReadData data)
        {
            return data.Antenna % 131 == 0;
        }
    }
}
