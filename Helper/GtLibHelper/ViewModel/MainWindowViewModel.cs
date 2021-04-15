using GtLibHelper.GtLibClasses;
using GtLibHelper.GtLibClasses.Implementable;
using GtLibHelper.GtLibClasses.NotImplementable;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using GtLibHelper.View;
using GtLibHelper.Services;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace GtLibHelper.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {

        public event EventHandler Exit;


        private OpenClassWindowService _openClassWindowService;
        private GtLibClassModel _gtLibClassModel;
        private ObservableCollection<AbstractLibClass> _gtLibClasses;

        private String _headers;
        private String _inputTxt;

        public ObservableCollection<AbstractLibClass> GtLibClassesObservable
        {
            get
            {
                return _gtLibClasses;
            }
            set
            {
                _gtLibClasses = value;
                OnPropertyChanged("GtLibClassesObservable");
            }
        }

        public String Headers
        {
            get
            {
                return _headers;
            }
            set
            {
                _headers = value;
                OnPropertyChanged("Headers");
            }
        }
        public String InputTxt
        {
            get
            {
                return _inputTxt;
            }
            set
            {
                _inputTxt = value;
                OnPropertyChanged("InputTxt");
            }
        }

        #region Delegate Commands

        public DelegateCommand EnumeratorButtonClickedCommand { get; private set; }
        public DelegateCommand SelectionButtonClickedCommand { get; private set; }
        public DelegateCommand CountingButtonClickedCommand { get; private set; }
        public DelegateCommand SummnationButtonClickedCommand { get; private set; }
        public DelegateCommand LinSearchButtonClickedCommand { get; private set; }
        public DelegateCommand MaxSearchButtonClickedCommand { get; private set; }

        public DelegateCommand StructButtonClickedCommand { get; private set; }
        public DelegateCommand ArrayEnumeratorButtonClickedCommand     { get; private set; }
        public DelegateCommand StringEnumeratorButtonClickedCommand    { get; private set; }
        public DelegateCommand IntervalEnumeratorButtonClickedCommand  { get; private set; }
        public DelegateCommand SeqInFileEnumeratorButtonClickedCommand { get; private set; }

        public DelegateCommand ExitButtonCommand { get; private set; }

        #endregion

        public MainWindowViewModel(GtLibClassModel model)
        {
            _gtLibClassModel = model;
            _openClassWindowService = new OpenClassWindowService();

            _headers = "";

            _openClassWindowService.ClassGenerated += ClassGenerated_Handler;

            ExitButtonCommand = new DelegateCommand(param => OnExitButton());

            EnumeratorButtonClickedCommand = new DelegateCommand(param => OnEnumeratorCreate());
            SelectionButtonClickedCommand = new DelegateCommand(param => OnSelectingCreate());
            CountingButtonClickedCommand = new DelegateCommand(param => OnCountingCreate());
            SummnationButtonClickedCommand = new DelegateCommand(param => OnSummnationCreate());
            LinSearchButtonClickedCommand = new DelegateCommand(param => OnLinSearchCreate());
            MaxSearchButtonClickedCommand = new DelegateCommand(param => OnMaxSearchCreate());

            ArrayEnumeratorButtonClickedCommand = new DelegateCommand(param => OnAddEnumerator("ArrayEnumerator"));
            StringEnumeratorButtonClickedCommand = new DelegateCommand(param => OnAddEnumerator("StringEnumerator"));
            IntervalEnumeratorButtonClickedCommand = new DelegateCommand(param => OnAddEnumerator("IntervalEnumerator"));
            SeqInFileEnumeratorButtonClickedCommand = new DelegateCommand(param => OnAddEnumerator("SeqInFileEnumerator"));



            StructButtonClickedCommand = new DelegateCommand(param => OnOwnStructCreate());

            GenerateMainFunc();
            PutingGtLibClassOnWindow();
        }

        private void OnExitButton()
        {
            Exit?.Invoke(this, new EventArgs());
        }

        #region Class create methods

        private void OnEnumeratorCreate()
        {
            if (_gtLibClassModel.CreateNewLibClass("", "Enumerator"))
                _openClassWindowService.OpenOneParamWindow(_gtLibClassModel);
        }
        private void OnSelectingCreate()
        {
            if (_gtLibClassModel.CreateNewLibClass("", "Selection"))
                _openClassWindowService.OpenOneParamWindow(_gtLibClassModel);
        }
        private void OnCountingCreate()
        {
            if (_gtLibClassModel.CreateNewLibClass("", "Counting"))
                _openClassWindowService.OpenOneParamWindow(_gtLibClassModel);
        }
        private void OnSummnationCreate()
        {
            if (_gtLibClassModel.CreateNewLibClass("", "Summnation"))
                _openClassWindowService.OpenTwoParamWindow(_gtLibClassModel);
        }
        private void OnLinSearchCreate()
        {
            if (_gtLibClassModel.CreateNewLibClass("", "LinSearch"))
                _openClassWindowService.OpenTwoParamWindow(_gtLibClassModel);
        }
        private void OnMaxSearchCreate()
        {
            if (_gtLibClassModel.CreateNewLibClass("", "MaxSearch"))
                _openClassWindowService.OpenThreeParamWindow(_gtLibClassModel);
        }
        private void OnOwnStructCreate()
        {
            if (_gtLibClassModel.CreateNewLibClass("", "Struct"))
                _openClassWindowService.OpenOwnStructWindow(_gtLibClassModel);
        }
        private void OnAddEnumerator(String selectedEnumerator) 
        {
            _openClassWindowService.OpenEnumeratorsWindow(_gtLibClassModel, selectedEnumerator);
        }
        #endregion

        private void GenerateMainFunc()
        {
            _gtLibClassModel.CreateNewLibClass("main", "Main");
            _gtLibClassModel.AddCurrentLibClass();

        }
        private void PutingGtLibClassOnWindow()
        {
            GtLibClassesObservable = new ObservableCollection<AbstractLibClass>();

            foreach (AbstractLibClass member in _gtLibClassModel.ListOfLibClasses)
            {
                AddNewHeaderToHeadersStringAtClassGeneration(member.NeededHeader);
                GtLibClassesObservable.Add(member);
            }
        }
        private void ClassGenerated_Handler(Object sender, EventArgs e)
        {
            PutingGtLibClassOnWindow();
        }
        private void AddNewHeaderToHeadersStringAtClassGeneration(String header) 
        {
            if (header == null)
                return;

            List<string> headears = new List<string>(Headers.Split("\r\n"));
            if (!headears.Contains(header))
                Headers += header + "\r\n";
                
        }
    }
}
