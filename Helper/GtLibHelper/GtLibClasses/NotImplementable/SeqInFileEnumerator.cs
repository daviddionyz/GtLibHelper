using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.GtLibClasses.NotImplementable
{
    public class SeqInFileEnumerator : AbstractLibClass
    {
        SeqInFileEnumerator(int ID, string name)
        {
            this.ID = ID;
            this.Name = name;
            this.Type = "SeqInFileEnumerator";
            this.NeededHeader = "include \"seqinfileenumerator.hpp\"";
            this.Text = $"private SeqInFileEnumerator<T> {name}()";
        }
    }
}
