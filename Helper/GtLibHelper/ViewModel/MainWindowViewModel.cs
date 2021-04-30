using GtLibHelper.GtLibClasses;
using System;
using System.Collections.Generic;
using GtLibHelper.Services;
using System.Collections.ObjectModel;
using GtLibHelper.Persistence;
using Ookii.Dialogs.Wpf;
using System.Diagnostics;
using GtLibHelper.OwnEventArgs;

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

        public DelegateCommand EnumeratorCommand { get; private set; }
        public DelegateCommand SelectionCommand { get; private set; }
        public DelegateCommand CountingCommand { get; private set; }
        public DelegateCommand SummnationCommand { get; private set; }
        public DelegateCommand LinSearchCommand { get; private set; }
        public DelegateCommand MaxSearchCommand { get; private set; }

        public DelegateCommand StructCommand { get; private set; }
        public DelegateCommand ArrayEnumeratorCommand { get; private set; }
        public DelegateCommand StringEnumeratorCommand { get; private set; }
        public DelegateCommand IntervalEnumeratorCommand { get; private set; }
        public DelegateCommand SeqInFileEnumeratorCommand { get; private set; }

        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand RunCommand { get; private set; }

        public DelegateCommand NewProjectCommand { get; private set; }
        public DelegateCommand LoadProjectCommand { get; private set; }
        public DelegateCommand SaveProjectCommand { get; private set; }

        public DelegateCommand ExitButtonCommand { get; private set; }
        public DelegateCommand DeleteClassCommand { get; private set; }

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

            EnumeratorCommand = new DelegateCommand(param => OnEnumeratorCreate());
            SelectionCommand = new DelegateCommand(param => OnSelectingCreate());
            CountingCommand = new DelegateCommand(param => OnCountingCreate());
            SummnationCommand = new DelegateCommand(param => OnSummnationCreate());
            LinSearchCommand = new DelegateCommand(param => OnLinSearchCreate());
            MaxSearchCommand = new DelegateCommand(param => OnMaxSearchCreate());
            StructCommand = new DelegateCommand(param => OnOwnStructCreate());

            ArrayEnumeratorCommand = new DelegateCommand(param => OnAddEnumerator("ArrayEnumerator"));
            StringEnumeratorCommand = new DelegateCommand(param => OnAddEnumerator("StringStreamEnumerator"));
            IntervalEnumeratorCommand = new DelegateCommand(param => OnAddEnumerator("IntervalEnumerator"));
            SeqInFileEnumeratorCommand = new DelegateCommand(param => OnAddEnumerator("SeqInFileEnumerator"));

            SaveCommand = new DelegateCommand(param => SaveCode());
            RunCommand = new DelegateCommand(param => RunCode());

            NewProjectCommand  = new DelegateCommand(param => NewProject());
            LoadProjectCommand = new DelegateCommand(param => LoadProject());
            SaveProjectCommand = new DelegateCommand(param => SaveProject());

            DeleteClassCommand = new DelegateCommand(param => OnDeleteClass());

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

        #region Save and Run
        private void SaveCode()
        {
            var ookiiDialog = new VistaFolderBrowserDialog();
            if (ookiiDialog.ShowDialog() == true)
            {
                _saveDirectoryPath = ookiiDialog.SelectedPath;
            }
            try
            {
                _dataAccess.SaveCppCode(_saveDirectoryPath, _gtLibClassModel, Headers, InputTxt);
                System.Windows.MessageBox.Show("Sikeres mentés");
            }
            catch (Exception e) 
            {
                System.Windows.MessageBox.Show(e.Message);
            }
        }
        private void RunCode()
        {
            if (_saveDirectoryPath != String.Empty)
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "cmd.exe";
                if (InputTxt != "")
                    psi.Arguments = @"/C cd c:\" + $"& cd {_saveDirectoryPath}" + " & g++ main.cpp" + "& a.exe input.txt" + "& pause";
                else
                    psi.Arguments = @"/C cd c:\" + $"& cd {_saveDirectoryPath}" + " & g++ main.cpp" + "& a.exe" + "& pause";
                using (Process p = Process.Start(psi))
                {
                    p.WaitForExit();
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Nincs mentett fájl.");
            }
        }
        #endregion

        #region Project save, load, new
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
            try
            {
                _dataAccess.SaveProject(path, _gtLibClassModel, Headers, InputTxt);
                System.Windows.MessageBox.Show("Sikeres mentés"); 
            }
            catch (DataAccessException e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
        }
        private void LoadProject()
        {
            string path = "";

            var ookiiDialog = new VistaOpenFileDialog();

            if (ookiiDialog.ShowDialog() == true)
            {
                path = ookiiDialog.FileName;
            }
            GtLibClassModel copyOfModel = new GtLibClassModel(_gtLibClassModel);

            try { 
                _gtLibClassModel.Clear();
                
                (string, string) headerAndInput = _dataAccess.LoadProject(path,_gtLibClassModel);

                Headers  = headerAndInput.Item1;
                InputTxt = headerAndInput.Item2;

                PutingGtLibClassOnWindow();
                System.Windows.MessageBox.Show("Sikeres betöltés");
            }
            catch (DataAccessException e)
            {
                System.Windows.MessageBox.Show(e.Message);
                _gtLibClassModel = copyOfModel;
            }
        }
        #endregion


        public void DragAndDropClassManager(string source, string destination) 
        {
            _gtLibClassModel.DragAndDropClassInstantiation(source,destination);
            PutingGtLibClassOnWindow();
        }
        private void OnDeleteClass() 
        {
            _openClassWindowService.OpenDeleteClassWindow(_gtLibClassModel);
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
