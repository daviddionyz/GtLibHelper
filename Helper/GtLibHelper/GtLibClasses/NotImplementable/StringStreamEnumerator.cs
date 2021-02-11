using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.GtLibClasses.NotImplementable
{
    public class StringStreamEnumerator : AbstractLibClass
    {
        StringStreamEnumerator(int ID, string name)
        {
            this.ID = ID;
            this.Name = name;
            this.Type = "StringStreamEnumerator";
            this.NeededHeader = "include \"stringstreamenumerator.hpp\"";
            this.Text = $"private StringStreamEnumerator<T> {name}()";
        }
    }
}
