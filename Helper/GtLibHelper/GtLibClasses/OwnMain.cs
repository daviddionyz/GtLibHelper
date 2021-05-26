namespace GtLibHelper.GtLibClasses
{
    public class OwnMain : AbstractLibClass
    {
        public OwnMain(string name)
        {
            this.Name = name;
            this.Type = "Main";
            this.NeededHeader = "";
            this.Text = "int main(int argc, char *argv[])" + "\r\n{\r\n   \r\n};";
        }
    }
}
