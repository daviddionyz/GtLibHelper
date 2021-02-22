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


        private bool checkTheNameIsFree(String name) {
            foreach (var gtLibClass in libClasses){
                if(gtLibClass.Name == name)
                    return false;
            }

            return true;
        }

        //main and struct is missing
        public void createNewLibClass(String name, String type){
            
            switch(type){
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
