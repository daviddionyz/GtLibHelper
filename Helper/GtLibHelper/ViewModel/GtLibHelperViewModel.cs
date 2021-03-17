using GtLibHelper.GtLibClasses;
using GtLibHelper.GtLibClasses.Implementable;
using GtLibHelper.GtLibClasses.NotImplementable;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using GtLibHelper.View;

namespace GtLibHelper.ViewModel
{
    public class GtLibHelperViewModel : ViewModelBase
    {
        private String _feedBackText;
        private String _className;

        public event EventHandler Exit;

        private List<AbstractLibClass> _libClasses;
        private AbstractLibClass _currentLibClass;

        private OneParamClassesWindow _oneParamClassesWindow;
        private TwoParamClassesWindow _twoParamClassesWindow;

        public String ClassName
        {
            get { return _className; }
            set
            {
                _className = value;
                CheckTheClassName(_className);
            }
        }
        public String Item { get; set; }
        public String T { get; set; }
        public String ClassText { get; set; }
        public String FeedBackText
        {
            get { return _feedBackText; }
            private set
            {
                _feedBackText = value;
                OnPropertyChanged("FeedBackText");
            }
        }

        public DelegateCommand EnumeratorButtonClickedCommand { get; private set; }
        public DelegateCommand SelectionButtonClickedCommand { get; private set; }
        public DelegateCommand CountingButtonClickedCommand { get; private set; }
        public DelegateCommand SummnationButtonClickedCommand { get; private set; }
        public DelegateCommand LinSearchButtonClickedCommand { get; private set; }
        public DelegateCommand MaxSearchButtonClickedCommand { get; private set; }

        public DelegateCommand ExitButtonCommand { get; private set; }


        public DelegateCommand OkButtonClickedCommand { get; private set; }
        public DelegateCommand CancelButtonClickedCommand { get; private set; }

        public GtLibHelperViewModel()
        {
            _libClasses = new List<AbstractLibClass>();

            ExitButtonCommand = new DelegateCommand(param => onExitButton());

            OkButtonClickedCommand = new DelegateCommand(param => OnOkButtonClicked());
            CancelButtonClickedCommand = new DelegateCommand(param => OnCancelButtonClicked());

            EnumeratorButtonClickedCommand = new DelegateCommand(param => OnEnumeratorCreate());


        }

        private void OnExitButton()
        {
            Exit?.Invoke(this, new EventArgs());
        }
        private void CheckTheClassName(string name)
        {
            Regex rex = new Regex("^[a-zA-Z]+$");

            foreach (var gtLibClass in _libClasses)
                if (gtLibClass.Name == name)
                {
                    FeedBackText = "A név már foglalt";
                    return;
                }

            if (!rex.IsMatch(name))
            {
                FeedBackText = "A név megadás helytelen";
                return;
            }

            FeedBackText = "Ok";
        }
        //main and struct is missing
        public AbstractLibClass CreateNewLibClass(String name, String type) {

            switch (type) {
                case "Main":
                    return null;
                case "Struct":
                    return new OwnStruct(name);
                case "Counting":
                    return new Counting(name);
                case "Enumerator":
                    return new Enumerator(name);
                case "LinSearch":
                    return new LinSearch(name);
                case "MaxSearch":
                    return new MaxSearch(name);
                case "Selection":
                    return new Selection(name);
                case "Summation":
                    return new Summation(name);
                case "ArrayEnumerator":
                    return new ArrayEnumerator(name);
                case "IntervalEnumerator":
                    return new IntervalEnumerator(name);
                case "SeqInFileEnumerator":
                    return new SeqInFileEnumerator(name);
                case "StringStreamEnumerator":
                    return new StringStreamEnumerator(name);
            }
            return null;
        }
        private void AddCurrentLibClassToList()
        {
            switch (_currentLibClass.Type)
            {
                case "Main":
                    break;
                case "Struct":
                    break;
                case "Counting":
                    break;
                case "Enumerator":
                    Enumerator ownEnum = (Enumerator)_currentLibClass;
                    ownEnum.Name = ClassName;
                    ownEnum.Item = Item;
                    ownEnum.Text = ClassText;
                    _libClasses.Add(ownEnum);
                    break;
                case "LinSearch":
                    break;
                case "MaxSearch":
                    break;
                case "Selection":
                    break;
                case "Summation":
                    break;
                case "ArrayEnumerator":
                    break;
                case "IntervalEnumerator":
                    break;
                case "SeqInFileEnumerator":
                    break;
                case "StringStreamEnumerator":
                    break;
            }
        }
        private void OnEnumeratorCreate()
        {
            //Console.WriteLine("helloo world");
            _twoParamClassesWindow = null;
            _oneParamClassesWindow = new OneParamClassesWindow();
            _oneParamClassesWindow.DataContext = this;

            _currentLibClass = CreateNewLibClass("", "Enumerator");

            _oneParamClassesWindow.ShowDialog();
        }
        private void OnOkButtonClicked()
        {
            AddCurrentLibClassToList();
            ClosingSeconderyWindow();
            ResetClassesWindowProperties();
        }
        private void OnCancelButtonClicked()
        {
            ClosingSeconderyWindow();
        }


        private void ClosingSeconderyWindow()
        {
            if (_oneParamClassesWindow != null)
                _oneParamClassesWindow.Close();
            else
                _twoParamClassesWindow.Close();
        }
        private void ResetClassesWindowProperties() 
        {
            ClassName = "";
            Item = "";
            T = "";
            ClassText = "";
            FeedBackText = "";
        }


    }
}
