using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.GtLibClasses.Implementable
{
    public class Selection : AbstractLibClass 
    {
        public Selection(int ID, String name)
        {
            this.ID = ID;
            this.Name = name;
            this.Type = "Selection";
            this.NeededHeader = "include \"selection.hpp\"";
            this.Text = $"class {name}" + ": public Selection<T>" +
                "{ \r\n" +
                "private: \r\n" +
                "\r\n" +
                "protected: \r\n" +
                "   void init() override final {}\r\n" +
                "   void body(const T& e) override final {}\r\n" +
                "   \r\n" +
                "public: \r\n" +
                "   \r\n" +
                "};\r\n";
        }
    }
}
