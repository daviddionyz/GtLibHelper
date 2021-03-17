using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.GtLibClasses.Implementable
{
    public class LinSearch : TwoParamClass
    {
        public LinSearch(string name)
        {
            this.Name = name;
            this.Type = "LinSearch";
            this.NeededHeader = "include \"linsearch.hpp\"";
            this.Text = $"class {name}" + " : public LinSearch<A>\r\n" +
                "{ \r\n" +
                "private: \r\n" +
                "\r\n" +
                "public: \r\n" +
                "   bool cond(const A& e) const override {}\r\n" +
                "}\r\n";
        }
    }
}

