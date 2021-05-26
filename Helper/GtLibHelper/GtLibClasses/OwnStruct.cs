namespace GtLibHelper.GtLibClasses
{
    public class OwnStruct : AbstractLibClass
    {
        public OwnStruct(string name)
        {
            this.Name = name;
            this.Type = "Struct";
            this.NeededHeader = "";
            this.Text = $"struct _name_" + "\r\n{\r\n   \r\n};";
        }

        public override void RefreshText()
        {
            this.Text = $"struct {Name}" + "\r\n{\r\n   \r\n};";
        }
    }
}
