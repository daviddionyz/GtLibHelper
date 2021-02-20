using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.GtLibClasses.Implementable
{
    public class Enumerator : AbstractLibClass
    {
        public Enumerator(string name)
        {
            this.Name = name;
            this.Type = "Enumerator";
            this.NeededHeader = "include \"enumerator.hpp\"";
            this.Text = $"class {name}" + ": public Enumerator<T>" +
                "{ \r\n" +
                "private: \r\n" +
                "\r\n" +
                "public: \r\n" +
                "   void first()         {} \r\n" +
                "   void next()          {} \r\n" +
                "   bool end() const     {} \r\n" +
                "   T current() const {} \r\n" +
                "};\r\n";
        }
    }
    
}
