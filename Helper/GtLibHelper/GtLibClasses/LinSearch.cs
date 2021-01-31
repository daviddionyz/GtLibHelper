using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.GtLibClasses
{
    public class LinSearch : AbstractLibClass
    {
        public LinSearch(int ID, string name)
        {
            this.ID = ID;
            this.Name = name;
            this.Type = "LinSearch";
            this.NeededHeader = "include \"linsearch.hpp\"";
            this.Text = $"class {name}" + " : public LinSearch<A>\r\n" +
                "{ \r\n" +
                "   bool cond(const A& e) const override {\r\n" +
                "   \r\n" +
                "   }\r\n" +
                "}\r\n";
        }
    }
}

