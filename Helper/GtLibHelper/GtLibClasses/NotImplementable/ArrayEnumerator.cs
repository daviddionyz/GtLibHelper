using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.GtLibClasses.NotImplementable
{
    public class ArrayEnumerator : AbstractLibClass
    {


        ArrayEnumerator(int ID, string name)
        {
            this.ID = ID;
            this.Name = name;
            this.Type = "ArrayEnumerator";
            this.NeededHeader = "include \"arrayenumerator.hpp\"";
            this.Text = $"private ArrayEnumerator<T> {name}()";


            //this.Text = $"class {name}" + ": public ArrayEnumerator<T>" +
            //    "{ \r\n" +
            //    "private: \r\n" +
            //    "\r\n" +
            //    "public: \r\n" +
            //    "   void first()         override { _ind = 0; } \r\n" +
            //    "   void next()          override { ++_ind; } \r\n" +
            //    "   bool end()     const override { return _ind>=_vect->size(); } \r\n" +
            //    "   T current() const override { return (*_vect)[_ind]; } \r\n" +
            //    "};\r\n";
        }
    }
}
