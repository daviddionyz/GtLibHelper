using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.GtLibClasses.Implementable
{
    public class Summation : TwoParamClass
    {
        public Summation(string name)
        {
            this.Name = name;
            this.Type = "Summation";
            this.NeededHeader = "include \"summation.hpp\"";
            this.Text = "class _name_" + " : public Summation<A,T>\r\n" +
                "{ \r\n" +
                "private: \r\n" +
                "\r\n" +
                "public: \r\n" +
                "   T func(const A& e) const override {}\r\n" +
                "   T netural() const override {}\r\n" +
                "   T add( const A& a, const A& b) const override {}\r\n" +
                "} \r\n";
        }

        public override void RefreshText()
        {
            this.Text = $"class {Name}" + $" : public Summation<{Item},{T}>\r\n" +
                "{ \r\n" +
                "private: \r\n" +
                "\r\n" +
                "public: \r\n" +
                $"   {T} func(const {Item}& e)" + " const override {}\r\n" +
                $"   {T} netural()" + " const override {}\r\n" +
                $"   {T} add( const {Item}& a, const {Item}& b)" + " const override {}\r\n" +
                "} \r\n";
        }
    }
}
