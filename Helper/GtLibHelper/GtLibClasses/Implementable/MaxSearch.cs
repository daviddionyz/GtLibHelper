namespace GtLibHelper.GtLibClasses.Implementable
{
    public class MaxSearch : ThreeParamClass
    {
        public MaxSearch(string name)
        {
            this.Name = name;
            this.Type = "MaxSearch";
            this.NeededHeader = "#include \"gtlib\\maxsearch.hpp\"";
            this.Text = "class _name_" + " : public MaxSearch<Item, Value, Compare>\r\n" +
                "{ \r\n" +
                "private: \r\n" +
                "\t\r\n" +
                "protected: \r\n" +
                "\tValue func(const Item& e) const override { };\r\n" +
                "\tbool  cond(const Item& e) const override { return true;}\r\n" +
                "public: \r\n" +
                "}\r\n";
        }


        public override void RefreshText()
        {
            this.Text = $"class {Name} " + $": public MaxSearch<{Item}, {T}, {Compare}<{T}>>\r\n" +
                "{ \r\n" +
                "private: \r\n" +
                "   \r\n" +
                "protected: \r\n" +
                $"\t{T} func(const {Item}& e) " + " const override { };\r\n" +
                $"\tbool  cond(const {Item}& e) " + " const override { return true;}\r\n" +
                "public: \r\n" +
                "}\r\n";
        }
    }
}
