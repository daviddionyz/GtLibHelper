using System;

namespace GtLibHelper.GtLibClasses.Implementable
{
    public class Selection : OneParamClass
    {
        public Selection(String name)
        {
            this.Name = name;
            this.Type = "Selection";
            this.NeededHeader = "#include \"gtlib\\selection.hpp\"";
            this.Text = "class _name_" + ": public Selection<Item>" +
                "{ \r\n" +
                "private: \r\n" +
                "\r\n" +
                "protected: \r\n" +
                "\t\r\n" +
                "public: \r\n" +
                "bool cond(const Item& e) const override { return true;} \r\n" +
                "\t\r\n" +
                "};\r\n";
        }

        public override void RefreshText()
        {
            this.Text = $"class {Name} " + $": public Selection<{Item}>" +
                "{ \r\n" +
                "private: \r\n" +
                "\r\n" +
                "protected: \r\n" +
                "\t\r\n" +
                "public: \r\n" +
                $"bool cond(const {Item}& e) const override" + " { return true;} \r\n" +
                "\t\r\n" +
                "};\r\n";
        }
    }
}
