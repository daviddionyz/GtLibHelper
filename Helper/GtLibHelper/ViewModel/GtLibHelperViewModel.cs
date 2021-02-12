using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.ViewModel
{
    public class GtLibHelperViewModel : ViewModelBase
    {   
        private List<AbstractLibClass> libClasses;

        public GtLibHelperViewModel(){
            libClasses = new List<AbstractLibClass>;
        }

        
        private bool checkTheNameIsFree(String name){
            for(var class : libClasses){
                if(class.name == name)
                    return false;
            }

            return true;
        }


        //main and struct is missing
        public void createNewLibClass(String name, String type){
            
            switch(type){
                case "Counting":
                    libClasses.add(new Counting(name));
                    break;
                case "Enumerator":
                    libClasses.add(new Enumerator(name));
                    break;
                case "LinSearch":
                    libClasses.add(new LinSearch(name));
                    break;
                case "MaxSearch":
                    libClasses.add(new MaxSearch(name));
                    break;
                case "Selection":
                    libClasses.add(new Selection(name));
                    break;
                case "Summation":
                    libClasses.add(new Summation(name));
                    break;
                case "ArrayEnumerator":
                    libClasses.add(new ArrayEnumerator(name));
                    break;
                case "IntervalEnumerator":
                    libClasses.add(new IntervalEnumerator(name));
                    break;
                case "SeqInFileEnumerator":
                    libClasses.add(new SeqInFileEnumerator(name));
                    break;
                case "StringStreamEnumerator":
                    libClasses.add(new StringStreamEnumerator(name));
                    break;

            }
        }




    }
}
