namespace GtLibHelper.GtLibClasses.NotImplementable
{
    public class IntervalEnumerator : AbstractLibClass
    {
        public IntervalEnumerator(string name)
        {
            this.Name = name;
            this.Type = "IntervalEnumerator";
            this.NeededHeader = "#include \"gtlib\\enumerator.hpp\"";
            this.Text = $"private IntervalEnumerator<T> ${name}()";
        }
    }
}
