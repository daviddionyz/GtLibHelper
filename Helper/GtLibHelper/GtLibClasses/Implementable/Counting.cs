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
            this.NeededHeader = "#include \"counting.hpp\"";
            this.Text = "class _name_ " + ": public Counting<Item>" +
                "{ \r\n" +
                "private: \r\n" +
                "\r\n" +
                "public: \r\n" +
                "\tint neutral() const final override { return 0; } \r\n" +
                "\tint add(const int &a, const int &b) const final override { return a + b; } \r\n" +
                "\tint func(const Item &e) const final override { return 1; } \r\n" +
                "};\r\n";

        }

        public override void RefreshText() 
        {
            this.Text = $"class {Name}" + $": public Counting<{Item}>" +
                "{ \r\n" +
                "private: \r\n" +
                "\r\n" +
                "public: \r\n" +
                "\tint neutral() const final override { return 0; } \r\n" +
                "\tint add(const int &a, const int &b) const final override { return a + b; } \r\n" +
                $"\tint func(const {Item} &e)" + "const final override { return 1; } \r\n" +
                "};\r\n";
        }
    }
}
