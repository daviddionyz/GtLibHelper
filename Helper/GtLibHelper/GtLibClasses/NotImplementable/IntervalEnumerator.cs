using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.GtLibClasses.NotImplementable
{
    public class IntervalEnumerator : AbstractLibClass
    {
        public IntervalEnumerator(string name)
        {
            this.Name = name;
            this.Type = "IntervalEnumerator";
            this.NeededHeader = "#include \"enumerator.hpp\"";
            this.Text = $"private IntervalEnumerator<T> ${name}()";
        }
    }
}
