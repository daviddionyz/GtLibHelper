using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.OwnEventArgs
{
    public class EnumeratorCreatedEventArgs : EventArgs
    {
        public String Type { get; set; }

        public EnumeratorCreatedEventArgs(String type) 
        {
            Type = type;
        }
    }
}
