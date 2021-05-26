namespace GtLibHelper.GtLibClasses.NotImplementable
{
    public class ArrayEnumerator : AbstractLibClass
    {
        public ArrayEnumerator(string name)
        {
            this.Name = name;
            this.Type = "ArrayEnumerator";
            this.NeededHeader = "#include \"gtlib\\arrayenumerator.hpp\"";
            this.Text = $"private ArrayEnumerator<T> {name}()";
        }
    }
}
