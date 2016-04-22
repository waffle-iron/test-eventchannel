using System;

namespace EventChannel
{
    public sealed class TagReadData
    {
        public int Antenna { get; private set; }
        public string Data { get; private set; }

        public TagReadData(int antenna, string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("antenna and data arguments cannot be null or whitespace.");
            }

            Antenna = antenna;
            Data = data;
        }
    }
}
