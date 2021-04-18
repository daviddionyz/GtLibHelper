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
            this.NeededHeader = "#include \"gtlib\\linsearch.hpp\"";
            this.Text = "class _name_" + " : public LinSearch<A,Bool>\r\n" +
                "{ \r\n" +
                "private: \r\n" +
                "\r\n" +
                "public: \r\n" +
                "\tbool cond(const A& e) const override {}\r\n" +
                "}\r\n";
        }

        public override void RefreshText()
        {
            this.Text = $"class {Name} " + $" : public LinSearch<{Item},{T}>\r\n" +
                "{ \r\n" +
                "private: \r\n" +
                "\r\n" +
                "public: \r\n" +
                $"\tbool cond(const {Item}& e) " + " const override {}\r\n" +
                "}\r\n";
        }
    }
}

