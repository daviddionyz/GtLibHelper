namespace GtLibHelper.GtLibClasses.NotImplementable
{
    public class StringStreamEnumerator : AbstractLibClass
    {
        public StringStreamEnumerator(string name)
        {
            this.Name = name;
            this.Type = "StringStreamEnumerator";
            this.NeededHeader = "#include \"gtlib\\stringstreamenumerator.hpp\"";
            this.Text = $"private StringStreamEnumerator<T> {name}()";
        }
    }
}
