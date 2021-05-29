using GtLibHelper.GtLibClasses;
using GtLibHelper.GtLibClasses.Implementable;
using GtLibHelper.Services;
using System;
using System.IO;


namespace GtLibHelper.Persistence
{
    public class DataAccess
    {
        #region Public methods
        /// <summary>
        /// Save the cpp code to the given path
        /// </summary>
        /// <param name="path">path where will be saved the cpp file</param>
        /// <param name="model">gtLib model where are the classes</param>
        /// <param name="header">include headers text</param>
        /// <param name="inputTxt">input txt for cpp file</param>
        public void SaveCppCode(string path, GtLibClassModel model, string header, string inputTxt)
        {
            try
            {
                SaveGtLibClassHpp(path);

                if (inputTxt != null)
                {
                    StreamWriter inputTxtWriter = new StreamWriter(path + "\\input.txt");
                    inputTxtWriter.WriteLine(inputTxt);
                    inputTxtWriter.Close();
                    inputTxtWriter.Dispose();
                }

                StreamWriter writer = new StreamWriter(path + "\\main.cpp");
                //headers
                writer.WriteLine(header);
                writer.Flush();
                //save structs
                foreach (AbstractLibClass member in model.ListOfLibClasses)
                {
                    if (member.Type != "Struct")
                    {
                        writer.WriteLine(member.Text);
                        writer.Flush();
                    }
                }
                //save classes
                foreach (AbstractLibClass member in model.ListOfLibClasses)
                {
                    if (member.Type != "Main" && member.Type != "Struct")
                    {
                        writer.WriteLine(member.Text);
                        writer.Flush();
                    }
                }
                //save main
                foreach (AbstractLibClass member in model.ListOfLibClasses)
                {
                    if (member.Type == "Main")
                    {
                        writer.WriteLine(member.Text);
                        break;
                    }
                }
                writer.Close();
                writer.Dispose();
            }
            catch (Exception)
            {
                throw new DataAccessException("The main.cpp file save failed.");
            }
        }
        /// <summary>
        /// Save the project for the given path
        /// </summary>
        /// <param name="path">path where will be saved the cpp file</param>
        /// <param name="model">gtLib model where are the classes</param>
        /// <param name="header">include headers text</param>
        /// <param name="inputTxt">input txt for cpp file</param>
        public void SaveProject(string path, GtLibClassModel model, string header, string inputTxt)
        {
            if (path == null)
                return;

            try
            {
                StreamWriter writer = new StreamWriter(path);

                string delimeter = "&##&##delimeter##&##&";
                string delimeterClassSeparator = "@@@&&&{{{class}}}&&&@@@";
                writer.WriteLine(header);
                writer.WriteLine(delimeter);
                writer.WriteLine(inputTxt);
                writer.WriteLine(delimeter);
                writer.Flush();
                foreach (AbstractLibClass member in model.ListOfLibClasses)
                {
                    SaveGtLibClasses(writer, member);
                    writer.WriteLine(delimeterClassSeparator);
                    writer.Flush();
                }

                writer.Close();
                writer.Dispose();

            }
            catch (DataAccessException)
            {
                throw new DataAccessException("Project save failed.");
            }
        }
        /// <summary>
        /// Load a project from the given path
        /// </summary>
        /// <param name="path">path where the project is</param>
        /// <param name="model">gtLib model where will be added the classes</param>
        /// <returns>Giving back a pair one of them headers other one is input txt content</returns>
        public (string, string) LoadProject(string path, GtLibClassModel model)
        {
            try
            {
                StreamReader reader = new StreamReader(path);

                string delimeterMain = "&##&##delimeter##&##&";
                string delimeterClassSeparator = "@@@&&&{{{class}}}&&&@@@";

                string header = "";
                string inputTxt = "";

                string[] input = reader.ReadToEnd().Split(delimeterMain);
                header = input[0];
                inputTxt = input[1];
                foreach (string member in input[2].Split(delimeterClassSeparator))
                {
                    LoadGtLibClasses(member, model);
                }

                return (header, inputTxt);
            }
            catch (Exception)
            {
                throw new DataAccessException("Project load failed.");
            }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// It's helper method for saving project, save one class at time with it content
        /// </summary>
        /// <param name="writer">Stremwriter</param>
        /// <param name="gtLibClass">gtLib class what will be saved</param>
        private void SaveGtLibClasses(StreamWriter writer, AbstractLibClass gtLibClass)
        {
            string delimeter = "#&&#&&delimeter&&#&&#";

            switch (gtLibClass.Type)
            {
                case "Main":
                    OwnMain ownMain = (OwnMain)gtLibClass;
                    writer.WriteLine(ownMain.Type);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(ownMain.Name);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(ownMain.Text);

                    break;
                case "Struct":
                    OwnStruct ownStruct = (OwnStruct)gtLibClass;
                    writer.WriteLine(ownStruct.Type);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(ownStruct.Name);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(ownStruct.Text);

                    break;
                case "Counting":
                    Counting counting = (Counting)gtLibClass;
                    writer.WriteLine(counting.Type);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(counting.Name);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(counting.Item);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(counting.Text);

                    break;
                case "Enumerator":
                    Enumerator enumerator = (Enumerator)gtLibClass;
                    writer.WriteLine(enumerator.Type);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(enumerator.Name);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(enumerator.Item);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(enumerator.Text);

                    break;
                case "Selection":
                    Selection selection = (Selection)gtLibClass;
                    writer.WriteLine(selection.Type);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(selection.Name);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(selection.Item);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(selection.Text);

                    break;
                case "LinSearch":
                    LinSearch linSearch = (LinSearch)gtLibClass;
                    writer.WriteLine(linSearch.Type);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(linSearch.Name);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(linSearch.Item);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(linSearch.T);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(linSearch.Text);

                    break;
                case "Summation":
                    Summation summation = (Summation)gtLibClass;
                    writer.WriteLine(summation.Type);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(summation.Name);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(summation.Item);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(summation.T);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(summation.Text);

                    break;
                case "MaxSearch":
                    MaxSearch maxSearch = (MaxSearch)gtLibClass;
                    writer.WriteLine(maxSearch.Type);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(maxSearch.Name);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(maxSearch.Item);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(maxSearch.T);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(maxSearch.Compare);
                    writer.WriteLine(delimeter);
                    writer.WriteLine(maxSearch.Text);

                    break;
            }
        }
        /// <summary>
        /// It's helper method for loading project, it's load one class at time
        /// </summary>
        /// <param name="text">the raw string what were read from the path</param>
        /// <param name="model">gtLib model where the class will be putted</param>
        private void LoadGtLibClasses(string text, GtLibClassModel model)
        {
            string delimeterClassPartSeparator = "#&&#&&delimeter&&#&&#";

            string[] input = text.Split(delimeterClassPartSeparator);

            string type = input[0].Replace("\r\n", "");

            model.CreateNewLibClass(type);

            switch (type)
            {
                case "Main":
                    model.RefreshLibClassData(input[1].Replace("\r\n", ""), null, null, null, input[2]);
                    model.AddCurrentLibClass();
                    break;
                case "Struct":
                    model.RefreshLibClassData(input[1].Replace("\r\n", ""), null, null, null, input[2]);
                    model.AddCurrentLibClass();
                    break;
                case "Counting":
                    model.RefreshLibClassData(input[1].Replace("\r\n", ""), input[2].Replace("\r\n", ""), null, null, input[3]);
                    model.AddCurrentLibClass();
                    break;
                case "Enumerator":
                    model.RefreshLibClassData(input[1].Replace("\r\n", ""), input[2].Replace("\r\n", ""), null, null, input[3]);
                    model.AddCurrentLibClass();
                    break;
                case "Selection":
                    model.RefreshLibClassData(input[1].Replace("\r\n", ""), input[2].Replace("\r\n", ""), null, null, input[3]);
                    model.AddCurrentLibClass();
                    break;
                case "LinSearch":
                    model.RefreshLibClassData(input[1].Replace("\r\n", ""), input[2].Replace("\r\n", ""), input[3].Replace("\r\n", ""), null, input[4]);
                    model.AddCurrentLibClass();
                    break;
                case "Summation":
                    model.RefreshLibClassData(input[1].Replace("\r\n", ""), input[2].Replace("\r\n", ""), input[3].Replace("\r\n", ""), null, input[4]);
                    model.AddCurrentLibClass();
                    break;
                case "MaxSearch":
                    model.RefreshLibClassData(input[1].Replace("\r\n", ""), input[2].Replace("\r\n", ""), input[3].Replace("\r\n", ""), input[4].Replace("\r\n", ""), input[5]);
                    model.AddCurrentLibClass();
                    break;
            }

        }
        /// <summary>
        /// Write out gtLib classes headers form properties
        /// </summary>
        /// <param name="path">path where will be saved</param>
        private void SaveGtLibClassHpp(string path)
        {
            path += "\\gtlib";

            Directory.CreateDirectory(path);

            File.WriteAllText(path + "\\counting.hpp", Properties.Resources.counting);
            File.WriteAllText(path + "\\arrayenumerator.hpp", Properties.Resources.arrayenumerator);
            File.WriteAllText(path + "\\enumerator.hpp", Properties.Resources.enumerator);
            File.WriteAllText(path + "\\intervalenumerator.hpp", Properties.Resources.intervalenumerator);
            File.WriteAllText(path + "\\linsearch.hpp", Properties.Resources.linsearch);
            File.WriteAllText(path + "\\maxsearch.hpp", Properties.Resources.maxsearch);
            File.WriteAllText(path + "\\procedure.hpp", Properties.Resources.procedure);
            File.WriteAllText(path + "\\selection.hpp", Properties.Resources.selection);
            File.WriteAllText(path + "\\summation.hpp", Properties.Resources.summation);
            File.WriteAllText(path + "\\seqinfileenumerator.hpp", Properties.Resources.seqinfileenumerator);
            File.WriteAllText(path + "\\stringstreamenumerator.hpp", Properties.Resources.stringstreamenumerator);
        }
        #endregion
    }
}
