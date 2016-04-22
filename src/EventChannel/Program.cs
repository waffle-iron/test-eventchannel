using System;

namespace EventChannel
{
    class Program
    {
        static void Main(string[] args)
        {
            var physicalReader = new PhysicalReader("Physical Reader 1");
            var logicalReader = new LogicalReader("Logical Reader 1");
            var channel = new EventChannel<TagReadData>();

            logicalReader.TagReadListener.Bind(channel);
            physicalReader.TagReadEventSource.Bind(channel);

            for (var i = 0; i < 1000 * 1000; i++)
            {
                physicalReader.SimulateTagRead(new TagReadData(i, string.Format("{0: 00000000}", i)));
            }

            channel.WaitAll(TimeSpan.FromSeconds(60));
        }
    }
}
