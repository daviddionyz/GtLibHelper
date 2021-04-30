using GtLibHelper.GtLibClasses;
using GtLibHelper.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.ViewModel
{
    public class DeleteClassViewModel : ViewModelBase
    {
        private GtLibClassModel _gtLibClassModel;

        public DeleteClassViewModel(GtLibClassModel model) 
        {
            _gtLibClassModel = model;
            SetClassNames();

            DeleteButtonClickedCommand = new DelegateCommand(param => OnDeleteButtonClicked());
        }

        private List<String> _gtLibClassNames;
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
        private void SetClassNames()
        {
            GtLibClassesNames = new List<string>();

            foreach (AbstractLibClass member in _gtLibClassModel.ListOfLibClasses)
                if(member.Name != "main")
                    GtLibClassesNames.Add(member.Name);
        }

        private String _selectedClassName;
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

        private void ClassSelected() 
        {
            SelectedClassText = (_gtLibClassModel.ListOfLibClasses.Find(m => m.Name.Equals(SelectedClassName)))?.Text;
        }

        private String _selectedClassText;
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

        public DelegateCommand DeleteButtonClickedCommand { get; private set; }

        private void OnDeleteButtonClicked()
        {
            _gtLibClassModel.DeleteClassByName(SelectedClassName);
            SelectedClassName = null;
            SetClassNames();
        }
    }
}
