using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.GtLibClasses.Implementable
{
    public class Selection : OneParamClass 
    {
        public Selection(String name)
        {
            this.Name = name;
            this.Type = "Selection";
            this.NeededHeader = "#include \"gtlib\\selection.hpp\"";
            this.Text = "class _name_" + ": public Selection<T>" +
                "{ \r\n" +
                "private: \r\n" +
                "\r\n" +
                "protected: \r\n" +
                "\tvoid init() override final {}\r\n" +
                "\tvoid body(const T& e) override final {}\r\n" +
                "\t\r\n" +
                "public: \r\n" +
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
                "\tvoid init() override final {}\r\n" +
                $"\tvoid body(const {Item}& e)" + " override final {}\r\n" +
                "\t\r\n" +
                "public: \r\n" +
                "\t\r\n" +
                "};\r\n";
        }
    }
}
