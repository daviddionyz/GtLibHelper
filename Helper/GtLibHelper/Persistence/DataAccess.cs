﻿using GtLibHelper.GtLibClasses;
using GtLibHelper.GtLibClasses.Implementable;
using GtLibHelper.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GtLibHelper.Persistence
{
    public class DataAccess
    {

        public void SaveCppCode(string path, GtLibClassModel model, string header, string inputTxt) 
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

            //class content
            foreach (AbstractLibClass member in model.ListOfLibClasses)
            {
                if (member.Type != "Main")
                {
                    writer.WriteLine(member.Text);
                }
            }
            //main
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
        public void SaveProject(string path, GtLibClassModel model, string header, string inputTxt) 
        {
            StreamWriter writer = new StreamWriter(path);

            string delimeter               = "&##&##delimeter##&##&";
            string delimeterClassSeparator = "@@@&&&{{{class}}}&&&@@@";
            writer.WriteLine(header);
            writer.WriteLine(delimeter);
            writer.WriteLine(inputTxt);
            writer.WriteLine(delimeter);
            foreach (AbstractLibClass member in model.ListOfLibClasses) 
            {
                SaveGtLibClasses(writer, member);
                writer.WriteLine(delimeterClassSeparator);
            }
        }
        public (string,string) LoadProject(string path, GtLibClassModel model)
        {
            StreamReader reader = new StreamReader(path);

            string delimeterMain               = "&##&##delimeter##&##&";
            string delimeterClassSeparator     = "@@@&&&{{{class}}}&&&@@@";

            string header   = "";
            string inputTxt = "";

            string[] input = reader.ReadToEnd().Split(delimeterMain);
            header   = input[0];
            inputTxt = input[1];
            foreach (string member in input[2].Split(delimeterClassSeparator)) 
            {
                LoadGtLibClasses(member, model);
            }

            return (header,inputTxt);
        }

        public void SaveGtLibClasses(StreamWriter writer,AbstractLibClass gtLibClass) 
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

        public void LoadGtLibClasses(string text, GtLibClassModel model) 
        {
            string delimeterClassPartSeparator = "#&&#&&delimeter&&#&&#";

            string[] input = text.Split(delimeterClassPartSeparator);

            string type = input[0].Replace("\r\n","");

            model.CreateNewLibClass("",type);

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

        private void SaveGtLibClassHpp(string path) 
        {
            path += "\\gtlib";

            Directory.CreateDirectory(path);

            File.WriteAllText(path + "\\arrayenumerator.hpp"       , Properties.Resources.arrayenumerator);
            File.WriteAllText(path + "\\counting.hpp"              , Properties.Resources.counting);
            File.WriteAllText(path + "\\enumerator.hpp"            , Properties.Resources.enumerator);
            File.WriteAllText(path + "\\intervalenumerator.hpp"    , Properties.Resources.intervalenumerator);
            File.WriteAllText(path + "\\linsearch.hpp"             , Properties.Resources.linsearch);
            File.WriteAllText(path + "\\maxsearch.hpp"             , Properties.Resources.maxsearch);
            File.WriteAllText(path + "\\procedure.hpp"             , Properties.Resources.procedure);
            File.WriteAllText(path + "\\selection.hpp"             , Properties.Resources.selection);
            File.WriteAllText(path + "\\summation.hpp"             , Properties.Resources.summation);
            File.WriteAllText(path + "\\seqinfileenumerator.hpp"   , Properties.Resources.seqinfileenumerator);
            File.WriteAllText(path + "\\stringstreamenumerator.hpp", Properties.Resources.stringstreamenumerator);
        }
    }
}