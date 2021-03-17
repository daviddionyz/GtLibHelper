using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.GtLibClasses.Implementable
{
    public class Counting : OneParamClass
    {
        public Counting(string name)
        {
            this.Name = name;
            this.Type = "Counting";
            this.NeededHeader = "include \"counting.hpp\"";
            this.Text = $"class {name}" + ": public Counting<T>" +
                "{ \r\n" +
                "private: \r\n" +
                "\r\n" +
                "public: \r\n" +
                "   int neutral() const final override { return 0; } \r\n" +
                "   int add(const int &a, const int &b) const final override { return a + b; } \r\n" +
                "   int func(const Item &e) const final override { return 1; } \r\n" +
                "};\r\n";

        }
    }
}
