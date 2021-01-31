using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.GtLibClasses
{
    public abstract class AbstractLibClass
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string NeededHeader { get; set; }
        public string Text { get; set; }
    }
}
