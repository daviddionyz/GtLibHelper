using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.GtLibClasses
{
    public class OwnStruct : AbstractLibClass
    {
        public OwnStruct(string name)
        {
            this.Name = name;
            this.Type = "Struct";
            this.NeededHeader = "";
            this.Text = $"private Struct {name}" + "{   };";
        }
    }
}
