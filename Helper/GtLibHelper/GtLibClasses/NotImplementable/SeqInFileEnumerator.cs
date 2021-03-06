﻿namespace GtLibHelper.GtLibClasses.NotImplementable
{
    public class SeqInFileEnumerator : AbstractLibClass
    {
        public SeqInFileEnumerator(string name)
        {
            this.Name = name;
            this.Type = "SeqInFileEnumerator";
            this.NeededHeader = "#include \"gtlib\\seqinfileenumerator.hpp\"";
            this.Text = $"private SeqInFileEnumerator<T> {name}()";
        }
    }
}
