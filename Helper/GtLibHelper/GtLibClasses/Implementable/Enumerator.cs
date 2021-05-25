using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.GtLibClasses.Implementable
{
    public class Enumerator : OneParamClass
    {   
        public Enumerator(string name)
        {
            this.Name = name;
            this.Type = "Enumerator";
            this.NeededHeader = "#include \"gtlib\\enumerator.hpp\"";
            this.Text = "class _name_" + ": public Enumerator<Item>" +
                "{ \r\n" +
                "private: \r\n" +
                "\r\n" +
                "public: \r\n" +
                "\tvoid first()         {} \r\n" +
                "\tvoid next()          {} \r\n" +
                "\tbool end() const     {} \r\n" +
                "\tItem current() const {} \r\n" +
                "};\r\n";
        }

        public override void RefreshText()
        {
            this.Text = $"class {Name} " + $": public Enumerator<{Item}>" +
            "{ \r\n" +
            "private: \r\n" +
            "\r\n" +
            "public: \r\n" +
            "\tvoid first() {} \r\n" +
            "\tvoid next() {} \r\n" +
            "\tbool end() const {} \r\n" +
            $"\t{Item} current() const" + " {} \r\n" +
            "};\r\n";
        }
    }
    
}
