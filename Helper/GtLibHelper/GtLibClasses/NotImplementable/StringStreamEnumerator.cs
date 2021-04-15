using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.GtLibClasses.NotImplementable
{
    public class StringStreamEnumerator : AbstractLibClass
    {
        public StringStreamEnumerator(string name)
        {
            this.Name = name;
            this.Type = "StringStreamEnumerator";
            this.NeededHeader = "#include \"stringstreamenumerator.hpp\"";
            this.Text = $"private StringStreamEnumerator<T> {name}()";
        }
    }
}
