﻿namespace GtLibHelper.GtLibClasses
{
    public abstract class AbstractLibClass
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string NeededHeader { get; set; }
        public string Text { get; set; }

        public virtual void RefreshText() { }
    }
}
