using GtLibHelper.GtLibClasses;
using GtLibHelper.GtLibClasses.Implementable;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GtLibHelper.Services
{
    public class GtLibClassModel
    {
        #region Fields
        private List<AbstractLibClass> _libClasses;
        private AbstractLibClass _currentLibClass;
        #endregion

        #region Properties
        /// <summary>
        /// List of created gtlib classes
        /// </summary>
        public List<AbstractLibClass> ListOfLibClasses
        {
            get
            {
                return _libClasses;
            }
            private set
            {
                _libClasses = value;
            }
        }
        /// <summary>
        /// The currently generated gtlib class what will be added to gtlib list
        /// </summary>
        public AbstractLibClass CurrentLibClass
        {
            get
            {
                return _currentLibClass;
            }
            private set
            {
                _currentLibClass = value;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Basic constructor what will initial gtlib class list
        /// </summary>
        public GtLibClassModel()
        {
            ListOfLibClasses = new List<AbstractLibClass>();
        }
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="model">that gtlibmodel what will be copied</param>
        public GtLibClassModel(GtLibClassModel model)
        {
            ListOfLibClasses = new List<AbstractLibClass>();

            ListOfLibClasses.AddRange(model.ListOfLibClasses);
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Check if the given class name are correct
        /// </summary>
        /// <param name="name">class name</param>
        /// <returns>return true is class name is right</returns>
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
        /// <summary>
        /// Create a gtlib class and CurrentGtLibClass property will hold it
        /// </summary>
        /// <param name="type">class type</param>
        /// <returns>if class creation was success return true else false</returns>
        public bool CreateNewLibClass(String type)
        {
            switch (type)
            {
                case "Main":
                    CurrentLibClass = new OwnMain("main");
                    break;
                case "Struct":
                    CurrentLibClass = new OwnStruct("");
                    break;
                case "Counting":
                    CurrentLibClass = new Counting("");
                    break;
                case "Enumerator":
                    CurrentLibClass = new Enumerator("");
                    break;
                case "LinSearch":
                    CurrentLibClass = new LinSearch("");
                    break;
                case "MaxSearch":
                    CurrentLibClass = new MaxSearch("");
                    break;
                case "Selection":
                    CurrentLibClass = new Selection("");
                    break;
                case "Summation":
                    CurrentLibClass = new Summation("");
                    break;
            }

            return true;
        }
        /// <summary>
        /// Refreshing class text by using class refresh text method    
        /// </summary>
        /// <param name="name">class name</param>
        /// <param name="item">item type in string</param>
        /// <param name="T">t type in string</param>
        /// <param name="compare">it's only used by maxsearch only can has to status Great or Less</param>
        /// <param name="text">class text</param>
        public void RefreshLibClassData(String name, String item, String T, String compare, String text)
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
                    linSearch.T = T;
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
            CurrentLibClass.RefreshText();
        }
        /// <summary>
        /// Add current lib class to the list
        /// </summary>
        public void AddCurrentLibClass()
        {
            if (CurrentLibClass != null)
            {
                ListOfLibClasses.Add(CurrentLibClass);
                CurrentLibClass = null;
            }
        }
        /// <summary>
        /// Giving back the include for enumerator class
        /// </summary>
        /// <param name="type">enumerator class type</param>
        /// <returns>returning include string</returns>
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
        /// <summary>
        /// Reset the list of gtlib class and currunt gtlib property
        /// </summary>
        public void Clear()
        {
            ListOfLibClasses = new List<AbstractLibClass>();
            CurrentLibClass = null;
        }
        /// <summary>
        /// Delete class from list
        /// </summary>
        /// <param name="name">class name</param>
        public void DeleteClassByName(String name)
        {
            ListOfLibClasses.Remove(ListOfLibClasses.Find(member => member.Name.Equals(name)));
        }
        /// <summary>
        /// Adding instantiation to destination class 
        /// </summary>
        /// <param name="source">source class name</param>
        /// <param name="destination">destination class name</param>
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
        #endregion

        #region Private methods
        /// <summary>
        /// Searching for gtlib class type in list of gtlib classes
        /// </summary>
        /// <param name="name">class name</param>
        /// <returns>return gtlib class type if it's in list</returns>
        private string GetTypeByName(string name)
        {
            return ListOfLibClasses.Find(member => member.Name.Equals(name)).Type;
        }
        /// <summary>
        /// Insert class instantiation to destination class
        /// </summary>
        /// <param name="sourceClassName">source class name</param>
        /// <param name="name">destination class name</param>
        /// <param name="prefix">it will be putted befor instantiation</param>
        private void InsertClassInstantiation(string sourceClassName, string name, string prefix)
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
        #endregion
    }
}
