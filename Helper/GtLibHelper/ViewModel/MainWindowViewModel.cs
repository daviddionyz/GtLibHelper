using GtLibHelper.GtLibClasses;
using GtLibHelper.GtLibClasses.Implementable;
using GtLibHelper.GtLibClasses.NotImplementable;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using GtLibHelper.View;
using GtLibHelper.Services;

namespace GtLibHelper.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {

        public event EventHandler Exit;


        private ParamClassWindowService _paramClassWindowService;
        private GtLibClassModel _gtLibClassModel;

        public DelegateCommand EnumeratorButtonClickedCommand { get; private set; }
        public DelegateCommand SelectionButtonClickedCommand { get; private set; }
        public DelegateCommand CountingButtonClickedCommand { get; private set; }
        public DelegateCommand SummnationButtonClickedCommand { get; private set; }
        public DelegateCommand LinSearchButtonClickedCommand { get; private set; }
        public DelegateCommand MaxSearchButtonClickedCommand { get; private set; }
        public DelegateCommand ExitButtonCommand { get; private set; }

        public MainWindowViewModel(GtLibClassModel model)
        {
            _gtLibClassModel = model;
            _paramClassWindowService = new ParamClassWindowService();

            ExitButtonCommand = new DelegateCommand(param => OnExitButton());

            EnumeratorButtonClickedCommand = new DelegateCommand(param => OnEnumeratorCreate());
            SelectionButtonClickedCommand = new DelegateCommand(param => OnSelectingCreate());
            CountingButtonClickedCommand = new DelegateCommand(param => OnCountingCreate());
            SummnationButtonClickedCommand = new DelegateCommand(param => OnSummnationCreate());
            LinSearchButtonClickedCommand = new DelegateCommand(param => OnLinSearchCreate());
            MaxSearchButtonClickedCommand = new DelegateCommand(param => OnMaxSearchCreate());
        }

        private void OnExitButton()
        {
            Exit?.Invoke(this, new EventArgs());
        }

        private void OnEnumeratorCreate()
        {
            if(_gtLibClassModel.CreateNewLibClass("", "Enumerator"))
                _paramClassWindowService.OpenOneParamWindow(_gtLibClassModel);
        }
        private void OnSelectingCreate() 
        {
            if (_gtLibClassModel.CreateNewLibClass("", "Selection"))
                _paramClassWindowService.OpenOneParamWindow(_gtLibClassModel);
        }
        private void OnCountingCreate() 
        {
            if (_gtLibClassModel.CreateNewLibClass("", "Counting"))
                _paramClassWindowService.OpenOneParamWindow(_gtLibClassModel);
        }
        private void OnSummnationCreate() 
        {
            if (_gtLibClassModel.CreateNewLibClass("", "Summnation"))
                _paramClassWindowService.OpenTwoParamWindow(_gtLibClassModel);
        }
        private void OnLinSearchCreate() 
        {
            if (_gtLibClassModel.CreateNewLibClass("", "LinSearch"))
                _paramClassWindowService.OpenTwoParamWindow(_gtLibClassModel);
        }
        private void OnMaxSearchCreate() 
        {
            if (_gtLibClassModel.CreateNewLibClass("", "MaxSearch"))
                _paramClassWindowService.OpenThreeParamWindow(_gtLibClassModel);
        }

    }
}
