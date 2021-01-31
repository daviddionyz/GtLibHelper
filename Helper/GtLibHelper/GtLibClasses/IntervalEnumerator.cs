using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.GtLibClasses
{
    public class IntervalEnumerator : AbstractLibClass
    {
        IntervalEnumerator(int ID, string name)
        {
            this.ID = ID;
            this.Name = name;
            this.Type = "Enumerator";
            this.NeededHeader = "include \"enumerator.hpp\"";
            this.Text = $"class {name}" + ": public IntervalEnumerator" +
                "{ \r\n" +
                "private: \r\n" +
                "\r\n" +
                "public: \r\n" +
               $"   {name}(int m, int n): _m(m), _n(n)" + "{}" + " \r\n" + // ősosztály hvatkozás kell a kostruktorra 
                "};\r\n";
        }
    }
}
