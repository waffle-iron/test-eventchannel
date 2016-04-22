using System;
using System.Collections.Generic;

namespace EventChannel
{
    public sealed class TagReadEventArgs : EventArgs
    {
        public IEnumerable<TagReadData> Reads { get; private set; }

        public TagReadEventArgs(TagReadData[] reads)
        {
            if (reads == null)
            {
                throw new ArgumentNullException("reads");
            }

            Reads = reads;
        }
    }
}
