using GtLibHelper.GtLibClasses;
using System;
using System.Collections.Generic;
using GtLibHelper.Services;
using System.Collections.ObjectModel;
using GtLibHelper.OwnEventArgs;
using GtLibHelper.Persistence;
using Microsoft.Win32;
using System.Windows;
using Ookii.Dialogs.Wpf;
using System.Windows.Forms;
using System.Diagnostics;

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

        private DataAccess _dataAccess;
        private String _saveDirectoryPath;
        private String _projectSaveDirectoryPath;
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
        public DelegateCommand ArrayEnumeratorButtonClickedCommand { get; private set; }
        public DelegateCommand StringEnumeratorButtonClickedCommand { get; private set; }
        public DelegateCommand IntervalEnumeratorButtonClickedCommand { get; private set; }
        public DelegateCommand SeqInFileEnumeratorButtonClickedCommand { get; private set; }

        public DelegateCommand SaveButtonClickedCommand { get; private set; }
        public DelegateCommand RunButtonClickedCommand { get; private set; }

        public DelegateCommand NewProjectButtonClickedCommand { get; private set; }
        public DelegateCommand LoadProjectButtonClickedCommand { get; private set; }
        public DelegateCommand SaveProjectButtonClickedCommand { get; private set; }

        public DelegateCommand ExitButtonCommand { get; private set; }

        #endregion

        public MainWindowViewModel(GtLibClassModel model,DataAccess dataAccess)
        {
            _gtLibClassModel = model;
            _dataAccess = dataAccess;
            _openClassWindowService = new OpenClassWindowService();

            _headers = "";

            _openClassWindowService.ClassGenerated += ClassGenerated_Handler;
            _openClassWindowService.EnumeratorClassCreated += EnumeratorClassCreated_Handler;

            ExitButtonCommand = new DelegateCommand(param => OnExitButton());

            EnumeratorButtonClickedCommand = new DelegateCommand(param => OnEnumeratorCreate());
            SelectionButtonClickedCommand = new DelegateCommand(param => OnSelectingCreate());
            CountingButtonClickedCommand = new DelegateCommand(param => OnCountingCreate());
            SummnationButtonClickedCommand = new DelegateCommand(param => OnSummnationCreate());
            LinSearchButtonClickedCommand = new DelegateCommand(param => OnLinSearchCreate());
            MaxSearchButtonClickedCommand = new DelegateCommand(param => OnMaxSearchCreate());

            ArrayEnumeratorButtonClickedCommand = new DelegateCommand(param => OnAddEnumerator("ArrayEnumerator"));
            StringEnumeratorButtonClickedCommand = new DelegateCommand(param => OnAddEnumerator("StringStreamEnumerator"));
            IntervalEnumeratorButtonClickedCommand = new DelegateCommand(param => OnAddEnumerator("IntervalEnumerator"));
            SeqInFileEnumeratorButtonClickedCommand = new DelegateCommand(param => OnAddEnumerator("SeqInFileEnumerator"));

            SaveButtonClickedCommand = new DelegateCommand(param => SaveCode());
            RunButtonClickedCommand = new DelegateCommand(param => RunCode());

            NewProjectButtonClickedCommand  = new DelegateCommand(param => NewProject());
            LoadProjectButtonClickedCommand = new DelegateCommand(param => LoadProject());
            SaveProjectButtonClickedCommand = new DelegateCommand(param => SaveProject());

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

        private void SaveCode()
        {
            var ookiiDialog = new VistaFolderBrowserDialog();
            if (ookiiDialog.ShowDialog() == true)
            {
                _saveDirectoryPath = ookiiDialog.SelectedPath;
            }

            _dataAccess.SaveCppCode(_saveDirectoryPath,_gtLibClassModel,Headers,InputTxt);
        }
        private void RunCode()
        {
            if (_saveDirectoryPath != String.Empty)
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "cmd.exe";
                psi.Arguments = @"/C cd c:\" + $"& cd {_saveDirectoryPath}" + " & g++ main.cpp" + "& a.exe" + "& pause";
                using (Process p = Process.Start(psi))
                {
                    p.WaitForExit();
                }

            }
            else
            {
                // message box 
            }
        }

        private void NewProject() 
        {
            //messagebox to be sure 

            Headers  = "";
            InputTxt = "";

            _gtLibClassModel.Clear();

            GenerateMainFunc();
            PutingGtLibClassOnWindow();
        }
        private void SaveProject()
        {
            string path = "";

            var ookiiDialog = new VistaSaveFileDialog()
            {
                Filter = "*.gtp|*.gtp"
            };
            if (ookiiDialog.ShowDialog() == true)
            {
                path = ookiiDialog.FileName;
            }

            _dataAccess.SaveProject(path, _gtLibClassModel,Headers,InputTxt);
        }
        private void LoadProject()
        {
            string path = "";

            var ookiiDialog = new VistaOpenFileDialog();

            if (ookiiDialog.ShowDialog() == true)
            {
                path = ookiiDialog.FileName;
            }
            _gtLibClassModel.Clear();

            (string, string) headerAndInput = _dataAccess.LoadProject(path,_gtLibClassModel);

            Headers  = headerAndInput.Item1;
            InputTxt = headerAndInput.Item2;

            PutingGtLibClassOnWindow();
        }

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

        private void EnumeratorClassCreated_Handler(object sender, EnumeratorCreatedEventArgs e) 
        {
            AddNewHeaderToHeadersStringAtClassGeneration(_gtLibClassModel.GetHeaderForClass(e.Type));
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
