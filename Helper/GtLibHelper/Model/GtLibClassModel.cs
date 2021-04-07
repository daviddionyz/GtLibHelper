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
            get{ return _currentLibClass; } 
            private set{ _currentLibClass = value; } 
        }

        public GtLibClassModel() 
        {
            ListOfLibClasses = new List<AbstractLibClass>();
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
                    CurrentLibClass = null;
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
    }
}
