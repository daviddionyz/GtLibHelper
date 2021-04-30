using GtLibHelper.GtLibClasses;
using GtLibHelper.GtLibClasses.Implementable;
using GtLibHelper.GtLibClasses.NotImplementable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GtLibHelper.Services
{
    public class GtLibClassModel
    {
        private List<AbstractLibClass> _libClasses;
        private AbstractLibClass _currentLibClass;

        public List<AbstractLibClass> ListOfLibClasses {
            get{
                return _libClasses;
            }
            private set{
                _libClasses = value;
            }
        }
        public AbstractLibClass CurrentLibClass { 
            get
            { 
                return _currentLibClass;
            } 
            private set
            {
                _currentLibClass = value;
            } 
        }

        public GtLibClassModel() 
        {
            ListOfLibClasses = new List<AbstractLibClass>();
        }
        public GtLibClassModel(GtLibClassModel model) 
        {
            ListOfLibClasses = new List<AbstractLibClass>();

            ListOfLibClasses.AddRange(model.ListOfLibClasses);
        }

        public (bool, String) CheckTheClassName(string name)
        {
            Regex rex = new Regex("^[a-zA-Z]+$");

            foreach (var gtLibClass in ListOfLibClasses)
                if (gtLibClass.Name == name)
                {
                    return (false, "A név már foglalt");
                }

            if (!rex.IsMatch(name))
            {
                return (false, "A név megadás helytelen");
            }

            return (true, "Ok");
        }
        public bool CreateNewLibClass(String name, String type)
        {
            switch (type)
            {
                case "Main":
                    CurrentLibClass = new OwnMain(name);
                    break;
                case "Struct":
                    CurrentLibClass = new OwnStruct(name);
                    break;
                case "Counting":
                    CurrentLibClass = new Counting(name);
                    break;
                case "Enumerator":
                    CurrentLibClass = new Enumerator(name);
                    break;
                case "LinSearch":
                    CurrentLibClass = new LinSearch(name);
                    break;
                case "MaxSearch":
                    CurrentLibClass = new MaxSearch(name);
                    break;
                case "Selection":
                    CurrentLibClass = new Selection(name);
                    break;
                case "Summnation":
                    CurrentLibClass = new Summation(name);
                    break;
            }

            return true;
        }
        public void RefreshLibClassData(String name,String item, String T, String compare, String text)
        {
            switch (CurrentLibClass.Type)
            {
                case "Main":
                    OwnMain ownMain = (OwnMain)CurrentLibClass;

                    ownMain.Name = name;
                    ownMain.Text = text;

                    break;
                case "Struct":
                    OwnStruct ownStruct = (OwnStruct)CurrentLibClass;

                    ownStruct.Name = name;
                    ownStruct.Text = text;

                    break;
                case "Counting":
                    Counting counting = (Counting)CurrentLibClass;

                    counting.Name = name;
                    counting.Item = item;
                    counting.Text = text;

                    break;
                case "Enumerator":
                    Enumerator enumerator = (Enumerator)CurrentLibClass;

                    enumerator.Name = name;
                    enumerator.Item = item;
                    enumerator.Text = text;

                    break;
                case "Selection":
                    Selection selection = (Selection)CurrentLibClass;

                    selection.Name = name;
                    selection.Item = item;
                    selection.Text = text;

                    break;
                case "LinSearch":
                    LinSearch linSearch = (LinSearch)CurrentLibClass;

                    linSearch.Name = name;
                    linSearch.Item = item;
                    linSearch.T    = T;
                    linSearch.Text = text;

                    break;
                case "Summation":
                    Summation summation = (Summation)CurrentLibClass;

                    summation.Name = name;
                    summation.Item = item;
                    summation.T = T;
                    summation.Text = text;

                    break;
                case "MaxSearch":
                    MaxSearch maxSearch = (MaxSearch)CurrentLibClass;

                    maxSearch.Name = name;
                    maxSearch.Item = item;
                    maxSearch.T = T;
                    maxSearch.Compare = compare;
                    maxSearch.Text = text;

                    break;
                }
            }
        public void AddCurrentLibClass() 
        {
            if (CurrentLibClass != null) 
            {
                ListOfLibClasses.Add(CurrentLibClass);
                CurrentLibClass = null;
            }
        }
        public string GetHeaderForClass(string type)
        {
            switch (type)
            {
                case "ArrayEnumerator":
                    return "#include \"gtlib\\arrayenumerator.hpp\"";
                case "IntervalEnumerator":
                    return "#include \"gtlib\\enumerator.hpp\"";
                case "SeqInFileEnumerator":
                    return "#include \"gtlib\\seqinfileenumerator.hpp\"";
                case "StringStreamEnumerator":
                    return "#include \"gtlib\\stringstreamenumerator.hpp\"";
            }
            return null;
        }
        public void Clear() 
        {
            ListOfLibClasses = new List<AbstractLibClass>();
            CurrentLibClass = null;
        }
        public void DeleteClassByName(String name)
        {
            ListOfLibClasses.Remove(ListOfLibClasses.Find(member => member.Name.Equals(name)));
        }
        public void DragAndDropClassInstantiation(string source, string destination) 
        {
            if (source.Equals(destination) || source.Equals("main"))
                return;

            if (GetTypeByName(source).Equals("Struct"))
            {
                InsertClassInstantiation(source, destination, "struct");
            }
            else 
            {
                InsertClassInstantiation(source, destination, "");
            }
        }

        private string GetTypeByName(string name) 
        {
            return ListOfLibClasses.Find(member => member.Name.Equals(name)).Type;
        }

        private void InsertClassInstantiation(string sourceClassName,string name, string prefix) 
        {
            AbstractLibClass selectedClass = (ListOfLibClasses.Find(m => m.Name.Equals(name)));

            string[] str;

            if (selectedClass.Text.Contains("private:"))
            {
                str = selectedClass.Text.Split("private:");
                selectedClass.Text = str[0]
                    + "private:\r\n"
                    + $"\t{prefix} {sourceClassName} {sourceClassName.ToLower()}; \r\n"
                    + str[1];
            }
            else if (selectedClass.Text.Contains("public:"))
            {
                str = selectedClass.Text.Split("public:");
                selectedClass.Text = str[0]
                    + "public:\r\n"
                    + $"\t{prefix} {sourceClassName} {sourceClassName.ToLower()}; \r\n"
                    + str[1];
            }
            else if (selectedClass.Text.Contains("protected:"))
            {
                str = selectedClass.Text.Split("protected:");
                selectedClass.Text = str[0]
                    + "protected:\r\n"
                    + $"\t{prefix} {sourceClassName} {sourceClassName.ToLower()}; \r\n"
                    + str[1];
            }
            else
            {
                str = selectedClass.Text.Split("{");
                selectedClass.Text = str[0]
                    + "{\r\n"
                    + $"\t{prefix} {sourceClassName} {sourceClassName.ToLower()}; \r\n"
                    + str[1];
            }

            
        }
    }
}
