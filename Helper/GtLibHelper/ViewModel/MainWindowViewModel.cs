using GtLibHelper.GtLibClasses;
using GtLibHelper.OwnEventArgs;
using GtLibHelper.Persistence;
using GtLibHelper.Services;
using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace GtLibHelper.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields
        private OpenClassWindowService _openClassWindowService;
        private GtLibClassModel _gtLibClassModel;
        private ObservableCollection<AbstractLibClass> _gtLibClasses;

        private String _headers;
        private String _inputTxt;

        private DataAccess _dataAccess;
        private String _saveDirectoryPath;
        #endregion

        #region Propertis
        /// <summary>
        /// Class ,struct and main function list what are showen on window
        /// </summary>
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
        /// <summary>
        /// Nedeed headers include
        /// </summary>
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
        /// <summary>
        /// Input txt contant
        /// </summary>
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
        #endregion

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

        #region Constructors
        /// <summary>
        /// Connect the DelegateCommands to methods, and generate main function.
        /// </summary>
        /// <param name="model">GtLibModel class</param>
        /// <param name="dataAccess">DataAccess class</param>
        public MainWindowViewModel(GtLibClassModel model, DataAccess dataAccess)
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

            NewProjectCommand = new DelegateCommand(param => NewProject());
            LoadProjectCommand = new DelegateCommand(param => LoadProject());
            SaveProjectCommand = new DelegateCommand(param => SaveProject());

            DeleteClassCommand = new DelegateCommand(param => OnDeleteClass());

            GenerateMainFunc();
            PutingGtLibClassOnWindow();
        }
        #endregion

        #region Events and Event handlers
        public event EventHandler Exit;
        /// <summary>
        /// On Exit button click invoke Exit event
        /// </summary>
        private void OnExitButton()
        {
            Exit?.Invoke(this, new EventArgs());
        }
        /// <summary>
        /// On Delete button click, delete that class what were chosen by user
        /// </summary>
        private void OnDeleteClass()
        {
            _openClassWindowService.OpenDeleteClassWindow(_gtLibClassModel);
            PutingGtLibClassOnWindow();
        }
        /// <summary>
        /// When on enumeratorts window the user create new enumeratur this handler handels it
        /// </summary>
        /// <param name="sender">the event sender</param>
        /// <param name="e">Enumerator created event args</param>
        private void EnumeratorClassCreated_Handler(object sender, EnumeratorCreatedEventArgs e)
        {
            AddNewHeaderToHeadersStringAtClassGeneration(_gtLibClassModel.GetHeaderForClass(e.Type));
        }
        /// <summary>
        /// Handels when a class is generated on other window
        /// </summary>
        /// <param name="sender">the event sender</param>
        /// <param name="e">Event args</param>
        private void ClassGenerated_Handler(Object sender, EventArgs e)
        {
            PutingGtLibClassOnWindow();
        }
        #endregion

        #region Class create methods
        /// <summary>
        /// Button click handel to create Enumerator class
        /// </summary>
        private void OnEnumeratorCreate()
        {
            if (_gtLibClassModel.CreateNewLibClass("", "Enumerator"))
                _openClassWindowService.OpenOneParamWindow(_gtLibClassModel);
        }
        /// <summary>
        /// Button click handel to create Selecting class
        /// </summary>
        private void OnSelectingCreate()
        {
            if (_gtLibClassModel.CreateNewLibClass("", "Selection"))
                _openClassWindowService.OpenOneParamWindow(_gtLibClassModel);
        }
        /// <summary>
        /// Button click handel to create Counting class
        /// </summary>
        private void OnCountingCreate()
        {
            if (_gtLibClassModel.CreateNewLibClass("", "Counting"))
                _openClassWindowService.OpenOneParamWindow(_gtLibClassModel);
        }
        /// <summary>
        /// Button click handel to create Summnation class
        /// </summary>
        private void OnSummnationCreate()
        {
            if (_gtLibClassModel.CreateNewLibClass("", "Summnation"))
                _openClassWindowService.OpenTwoParamWindow(_gtLibClassModel);
        }
        /// <summary>
        /// Button click handel to create LinSearch class
        /// </summary>
        private void OnLinSearchCreate()
        {
            if (_gtLibClassModel.CreateNewLibClass("", "LinSearch"))
                _openClassWindowService.OpenTwoParamWindow(_gtLibClassModel);
        }
        /// <summary>
        /// Button click handel to create MaxSearch class
        /// </summary>
        private void OnMaxSearchCreate()
        {
            if (_gtLibClassModel.CreateNewLibClass("", "MaxSearch"))
                _openClassWindowService.OpenThreeParamWindow(_gtLibClassModel);
        }
        /// <summary>
        /// Button click handel to create OwnStruct class
        /// </summary>
        private void OnOwnStructCreate()
        {
            if (_gtLibClassModel.CreateNewLibClass("", "Struct"))
                _openClassWindowService.OpenOwnStructWindow(_gtLibClassModel);
        }
        /// <summary>
        /// Button click handel to create irray or interval or seq in file or string strem Enumerator class it depends on param
        /// </summary>
        /// <param name="selectedEnumerator">enumerator type</param>
        private void OnAddEnumerator(String selectedEnumerator)
        {
            _openClassWindowService.OpenEnumeratorsWindow(_gtLibClassModel, selectedEnumerator);
        }
        /// <summary>
        /// Create main function
        /// </summary>
        private void GenerateMainFunc()
        {
            _gtLibClassModel.CreateNewLibClass("main", "Main");
            _gtLibClassModel.AddCurrentLibClass();

        }
        #endregion

        #region Save and Run
        /// <summary>
        /// Open folder dialog boc where user can choose where to save cpp code. After that save the cpp code
        /// </summary>
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
                System.Windows.MessageBox.Show("Save wass success.");
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
        }
        /// <summary>
        /// Open cmd and run the cpp file
        /// </summary>
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
                System.Windows.MessageBox.Show("No such file.");
            }
        }
        #endregion

        #region Project save, load, new
        /// <summary>
        /// Create new project, make Headers and InputTxt properties null and call the model Clear method
        /// </summary>
        private void NewProject()
        {

            Headers = "";
            InputTxt = "";

            _gtLibClassModel.Clear();

            GenerateMainFunc();
            PutingGtLibClassOnWindow();
        }
        /// <summary>
        /// Open FileDialog window where user can choose where to save the project
        /// </summary>
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
                System.Windows.MessageBox.Show("Save wass success.");
            }
            catch (DataAccessException e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
        }
        /// <summary>
        /// Open file dialog where user can search for the project file
        /// </summary>
        private void LoadProject()
        {
            string path = "";

            var ookiiDialog = new VistaOpenFileDialog();

            if (ookiiDialog.ShowDialog() == true)
            {
                path = ookiiDialog.FileName;
            }
            GtLibClassModel copyOfModel = new GtLibClassModel(_gtLibClassModel);

            try
            {
                _gtLibClassModel.Clear();

                (string, string) headerAndInput = _dataAccess.LoadProject(path, _gtLibClassModel);

                Headers = headerAndInput.Item1;
                InputTxt = headerAndInput.Item2;

                PutingGtLibClassOnWindow();
                System.Windows.MessageBox.Show("Load wass success.");
            }
            catch (DataAccessException e)
            {
                System.Windows.MessageBox.Show(e.Message);
                _gtLibClassModel = copyOfModel;
            }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Managinjg drag and drop effect, the view call this method
        /// </summary>
        /// <param name="source">source class name</param>
        /// <param name="destination">destination class name</param>
        public void DragAndDropClassManager(string source, string destination)
        {
            _gtLibClassModel.DragAndDropClassInstantiation(source, destination);
            PutingGtLibClassOnWindow();
        }
        /// <summary>
        /// Filling up GtLibClassesObservable property with gtlib classes
        /// </summary>
        private void PutingGtLibClassOnWindow()
        {
            GtLibClassesObservable = new ObservableCollection<AbstractLibClass>();

            foreach (AbstractLibClass member in _gtLibClassModel.ListOfLibClasses)
            {
                AddNewHeaderToHeadersStringAtClassGeneration(member.NeededHeader);
                GtLibClassesObservable.Add(member);
            }
        }
        /// <summary>
        /// If the new header is not in Headers property then this method will add it.
        /// </summary>
        /// <param name="header">new header include</param>
        private void AddNewHeaderToHeadersStringAtClassGeneration(String header)
        {
            if (header == null)
                return;

            List<string> headears = new List<string>(Headers.Split("\r\n"));
            if (!headears.Contains(header))
                Headers += header + "\r\n";

        }
        #endregion
    }
}
