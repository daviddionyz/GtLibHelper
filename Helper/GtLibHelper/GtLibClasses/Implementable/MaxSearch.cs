using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.GtLibClasses.Implementable
{
    public class MaxSearch : ThreeParamClass
    {
        public MaxSearch(string name)
        {
            this.Name = name;
            this.Type = "MaxSearch";
            this.NeededHeader = "#include \"maxsearch.hpp\"";
            this.Text = "class _name_" + " : public MaxSearch<Item, Value, Compare>\r\n" +
                "{ \r\n" +
                "private: \r\n" +
                "\t\r\n" +
                "protected: \r\n" +
                "\tValue func(const Item& e) const override { };\r\n" +
                "\tbool  cond(const Item& e) const override { return true;}\r\n" +
                "public: \r\n" +
                "\tbool found()   const { return _l;}\r\n" +
                "\tValue opt()    const { return _opt;}\r\n" +
                "\tItem optElem() const { return _optelem;}\r\n" +
                "}\r\n";
        }


        public override void RefreshText()
        {
            this.Text = $"class {Name}" + $" : public MaxSearch<{Item}, {T}, {Compare}>\r\n" +
                "{ \r\n" +
                "private: \r\n" +
                "   \r\n" +
                "protected: \r\n" +
                $"\t{T} func(const {Item}& e) " + " const override { };\r\n" +
                $"\tbool  cond(const {Item}& e) " + " const override { return true;}\r\n" +
                "public: \r\n" +
                "\tbool found()   const { return _l;}\r\n" +
                $"\t{T} opt()   " + " const { return _opt;}\r\n" +
                $"\t{Item} optElem() " + "  const { return _optelem;}\r\n" +
                "}\r\n";
        }
    }
}

// template <typename Item, typename Value, typename Compare >
// class MaxSearch : public Procedure<Item, Value, Compare>
// {
// protected:
//     bool    _l;
//     Item    _optelem;
//     Value   _opt;
//     Compare _better;

//     void init() final override { _l = false;}
//     void body(const Item& e) final override;

//     virtual Value func(const Item& e) const = 0;
//     virtual bool  cond(const Item& e) const { return true;}

// public:
//     bool found()   const { return _l;}
//     Value opt()    const { return _opt;}
//     Item optElem() const { return _optelem;}
// };
