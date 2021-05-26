using GtLibHelper.GtLibClasses;
using GtLibHelper.Services;
using System;
using System.Collections.Generic;

namespace GtLibHelper.ViewModel
{
    public class DeleteClassViewModel : ViewModelBase
    {
        #region Fields
        private GtLibClassModel _gtLibClassModel;
        private List<String> _gtLibClassNames;
        private String _selectedClassText;
        private String _selectedClassName;
        #endregion

        #region Constructor
        /// <summary>
        /// Create DeleteClassViewModel
        /// </summary>
        /// <param name="model">It's GtLibClassModel what holds gtlib classes</param>
        public DeleteClassViewModel(GtLibClassModel model)
        {
            _gtLibClassModel = model;
            SetClassNames();

            DeleteButtonClickedCommand = new DelegateCommand(param => OnDeleteButtonClicked());
        }
        #endregion

        #region DelegateCommands
        public DelegateCommand DeleteButtonClickedCommand { get; private set; }
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
                OnPropertyChanged("SelectedClassName");
            }
        }
        /// <summary>
        /// IIf class is selected on view this property has it's text
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
            GtLibClassesNames = new List<string>();

            foreach (AbstractLibClass member in _gtLibClassModel.ListOfLibClasses)
                if (member.Name != "main")
                    GtLibClassesNames.Add(member.Name);
        }
        /// <summary>
        /// It's sets SelectedClassText property when class is selected in view 
        /// </summary>
        private void ClassSelected()
        {
            SelectedClassText = (_gtLibClassModel.ListOfLibClasses.Find(m => m.Name.Equals(SelectedClassName)))?.Text;
        }
        #endregion

        #region Events
        /// <summary>
        /// Delete class from model and reset GtLibClassesNames property and SelectedClassName
        /// </summary>
        private void OnDeleteButtonClicked()
        {
            _gtLibClassModel.DeleteClassByName(SelectedClassName);
            SelectedClassName = null;
            SetClassNames();
        }
        #endregion
    }
}
