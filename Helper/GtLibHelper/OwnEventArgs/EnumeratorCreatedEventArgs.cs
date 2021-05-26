using System;

namespace GtLibHelper.OwnEventArgs
{
    public class EnumeratorCreatedEventArgs : EventArgs
    {
        public String Type { get; set; }

        public EnumeratorCreatedEventArgs(string type)
        {
            this.Type = type;
        }
    }
}
