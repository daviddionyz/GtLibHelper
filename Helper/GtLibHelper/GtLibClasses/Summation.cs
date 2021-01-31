﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.GtLibClasses
{
    public class Summation : AbstractLibClass
    {
        public Summation(int ID, string name)
        {
            this.ID = ID;
            this.Name = name;
            this.Type = "Summation";
            this.NeededHeader = "include \"summation.hpp\"";
            this.Text = $"class {name}" + " : public Summation<A,T>\r\n" +
                "{\r\n" +
                "T func(const A& e) const override\r\n" +
                "{\r\n" +
                "   \r\n" +
                "}\r\n" +
                "T netural() const override\r\n" +
                "{\r\n" +
                "   \r\n" +
                "}\r\n" +
                "T add( const A& a, const A& b) const override\r\n" +
                "{\r\n" +
                "   \r\n" +
                "}\r\n";
        }
    }
}
