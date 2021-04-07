using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.OwnEventArgs
{
    public class NameCheckEventArgs : EventArgs
    {
        public String Name { get; set; }

        public NameCheckEventArgs(String name) 
        {
            Name = name;
        }
    }
}
