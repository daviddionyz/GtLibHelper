using GtLibHelper.GtLibClasses;
using GtLibHelper.OwnEventArgs;
using GtLibHelper.Services;
using System;
using System.Collections.Generic;

namespace GtLibHelper.ViewModel
{
    public class EnumeratorsWindowViewModel : ViewModelBase
    {
        #region Fields
        private GtLibClassModel _gtLibClassModel;
        private String _selectedEnumeratorType;
        private List<String> _gtLibClassNames;
        private String _selectedClassName;
        private String _selectedClassText;
        #endregion

        #region Constructors
        /// <summary>
        /// Create EnumeratorsWindowViewModel class
        /// </summary>
        /// <param name="gtLibClassModel">It's type is GtLibClassModel what holds gtlib classes</param>
        /// <param name="selectedEnumeratorType">It's type is string and hold the enumerator class type</param>
        public EnumeratorsWindowViewModel(GtLibClassModel gtLibClassModel, String selectedEnumeratorType)
        {
            _gtLibClassModel = gtLibClassModel;
            _selectedEnumeratorType = selectedEnumeratorType;
            SetClassNames();

            OkButtonClickedCommand = new DelegateCommand(param => OnOkButtonClicked());
        }
        #endregion

        #region DelegateCommands
        public DelegateCommand OkButtonClickedCommand { get; private set; }
        #endregion

        #region Properties
        /// <summary>
        /// It's holding gtlib classes name
        /// </summary>
        public List<String> GtLibClassesNames
        {
            get
            {
                return _gtLibClassNames;
            }
            private set
            {
                _gtLibClassNames = value;
                OnPropertyChanged("GtLibClassesNames");
            }
        }
        /// <summary>
        /// If class is selected on view this property has it's name
        /// </summary>
        public String SelectedClassName
        {
            get
            {
                return _selectedClassName;
            }
            set
            {
                _selectedClassName = value;
                ClassSelected();
            }
        }
        /// <summary>
        /// If class is selected on view this property has it's text
        /// </summary>
        public String SelectedClassText
        {
            get
            {
                return _selectedClassText;
            }
            set
            {
                _selectedClassText = value;
                OnPropertyChanged("SelectedClassText");
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// It's sets GtLibClassNames property, the names are get from model
        /// </summary>
        private void SetClassNames()
        {
            _gtLibClassNames = new List<string>();

            foreach (AbstractLibClass member in _gtLibClassModel.ListOfLibClasses)
                _gtLibClassNames.Add(member.Name);
        }
        /// <summary>
        /// Putting class instantiation to selected class, but it's not saved to the class it's just showed for view
        /// </summary>
        private void ClassSelected()
        {
            SelectedClassText = (_gtLibClassModel.ListOfLibClasses.Find(m => m.Name.Equals(SelectedClassName))).Text;

            string[] str;

            if (SelectedClassText.Contains("private:"))
            {
                str = SelectedClassText.Split("private:");
                SelectedClassText = str[0]
                    + "private:\r\n"
                    + $"\t{_selectedEnumeratorType}<> {_selectedEnumeratorType.ToLower()}; \r\n"
                    + str[1];
            }
            else if (SelectedClassText.Contains("public:"))
            {
                str = SelectedClassText.Split("public:");
                SelectedClassText = str[0]
                    + "public:\r\n"
                    + $"\t{_selectedEnumeratorType}<> {_selectedEnumeratorType.ToLower()}; \r\n"
                    + str[1];
            }
            else if (SelectedClassText.Contains("protected:"))
            {
                str = SelectedClassText.Split("protected:");
                SelectedClassText = str[0]
                    + "protected:\r\n"
                    + $"\t{_selectedEnumeratorType}<> {_selectedEnumeratorType.ToLower()}; \r\n"
                    + str[1];
            }
            else
            {
                str = SelectedClassText.Split("{");
                SelectedClassText = str[0]
                    + "{\r\n"
                    + $"\t{_selectedEnumeratorType}<> {_selectedEnumeratorType.ToLower()} = new {_selectedEnumeratorType}<>(); \r\n"
                    + str[1];
            }

        }
        /// <summary>
        /// It's rewrite selected class text with SelectedClassText property and raise ok button event
        /// </summary>
        private void OnOkButtonClicked()
        {
            (_gtLibClassModel.ListOfLibClasses.Find(m => m.Name.Equals(SelectedClassName))).Text = SelectedClassText;
            RaiseEnumeratorCalssCreated();
            RaiseOkButtonClicked();
        }
        #endregion

        #region Events
        public event EventHandler OkButtonClicked;
        private void RaiseOkButtonClicked()
        {
            OkButtonClicked?.Invoke(this, new EventArgs());
        }

        public event EventHandler<EnumeratorCreatedEventArgs> EnumeratorCalssCreated;
        private void RaiseEnumeratorCalssCreated()
        {
            EnumeratorCalssCreated?.Invoke(this, new EnumeratorCreatedEventArgs(_selectedEnumeratorType));
        }
        #endregion
    }
}
