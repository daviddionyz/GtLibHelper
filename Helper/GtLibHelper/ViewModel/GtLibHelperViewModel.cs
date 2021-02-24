using GtLibHelper.GtLibClasses;
using GtLibHelper.GtLibClasses.Implementable;
using GtLibHelper.GtLibClasses.NotImplementable;
using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.ViewModel
{
    public class GtLibHelperViewModel : ViewModelBase
    {
        private List<AbstractLibClass> libClasses;

        public GtLibHelperViewModel() {
            libClasses = new List<AbstractLibClass>();
        }


        private Tuple<Bool,String> checkTheNameIsFree(String name) {
            Tuple<Bool,String> result  = new Tuple<Bool,String>;

            foreach (var gtLibClass in libClasses){
                if(gtLibClass.Name == name)
                    result.First = false;
                    result.Second = "A név már foglalt";
                    return result;
            }

//            TODO:
//            regular expression to check the characters are allowed
//            Names can contain letters, digits and underscores
//            Names must begin with a letter or an underscore (_)
//            Names are case sensitive (myVar and myvar are different variables)
//            Names cannot contain whitespaces or special characters like !, #, %, etc.
//            Reserved words (like C++ keywords, such as int) cannot be used as names


            result.First = true;
            result.Second = "Ok";
            return result;
        }

        //main and struct is missing
        public void createNewLibClass(String name, String type){
            
            switch(type){
                case "Main":
                    break;
                case "Struct":
                    break;
                case "Counting":
                    libClasses.Add(new Counting(name));
                    break;
                case "Enumerator":
                    libClasses.Add(new Enumerator(name));
                    break;
                case "LinSearch":
                    libClasses.Add(new LinSearch(name));
                    break;
                case "MaxSearch":
                    libClasses.Add(new MaxSearch(name));
                    break;
                case "Selection":
                    libClasses.Add(new Selection(name));
                    break;
                case "Summation":
                    libClasses.Add(new Summation(name));
                    break;
                case "ArrayEnumerator":
                    libClasses.Add(new ArrayEnumerator(name));
                    break;
                case "IntervalEnumerator":
                    libClasses.Add(new IntervalEnumerator(name));
                    break;
                case "SeqInFileEnumerator":
                    libClasses.Add(new SeqInFileEnumerator(name));
                    break;
                case "StringStreamEnumerator":
                    libClasses.Add(new StringStreamEnumerator(name));
                    break;
            }
        }
    }
}
