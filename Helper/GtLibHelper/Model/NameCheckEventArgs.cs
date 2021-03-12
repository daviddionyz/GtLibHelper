using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.Model
{
    public class NameCheckEventArgs : EventArgs
    {
        public Tuple<bool, string> Tuple { get; set; }

        public NameCheckEventArgs() { }

        public NameCheckEventArgs(Tuple<bool, string> tuple) {
            this.Tuple = tuple;
        }


    }
}
