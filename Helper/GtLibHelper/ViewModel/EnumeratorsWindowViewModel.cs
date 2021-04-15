using GtLibHelper.GtLibClasses;
using GtLibHelper.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.ViewModel
{
    public class EnumeratorsWindowViewModel : ViewModelBase
    {
        private GtLibClassModel _gtLibClassModel;
        private String _selectedEnumeratorType;

        public EnumeratorsWindowViewModel(GtLibClassModel gtLibClassModel, String selectedEnumeratorType) 
        {
            _gtLibClassModel = gtLibClassModel;
            _selectedEnumeratorType = selectedEnumeratorType;
            SetClassNames();

            OkButtonClickedCommand = new DelegateCommand(param => OnOkButtonClicked());
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
            _gtLibClassNames = new List<string>();

            foreach (AbstractLibClass member in _gtLibClassModel.ListOfLibClasses) 
            {
                _gtLibClassNames.Add(member.Name);
            }
        }

        private String _selectedClassName;
        public String SelectedClass 
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

        private void ClassSelected() 
        {
            SelectedClassText = ( _gtLibClassModel.ListOfLibClasses.Find(m => m.Name == SelectedClass) ).Text;

            string[] str;

            if (SelectedClassText.Contains("private:"))
            {
                str = SelectedClassText.Split("private:");
                SelectedClassText = str[0] 
                    + "private:\r\n"
                    + $"\t{_selectedEnumeratorType}<> {_selectedEnumeratorType.ToLower()}; \r\n"
                    + str[1].Substring(8);
            }
            else if (SelectedClassText.Contains("public:")) 
            {
                str = SelectedClassText.Split("public:");
                SelectedClassText = str[0] 
                    + "public:\r\n" 
                    + $"\t{_selectedEnumeratorType}<> {_selectedEnumeratorType.ToLower()}; \r\n" 
                    + str[1].Substring(7);
            }
            else if (SelectedClassText.Contains("protected:"))
            {
                str = SelectedClassText.Split("protected:");
                SelectedClassText = str[0]
                    + "protected:\r\n"
                    + $"\t{_selectedEnumeratorType}<> {_selectedEnumeratorType.ToLower()}; \r\n"
                    + str[1].Substring(10);
            }
            else
            {
                str = SelectedClassText.Split("{");
                SelectedClassText = str[0]
                    + "{\r\n"
                    + $"\t{_selectedEnumeratorType}<> {_selectedEnumeratorType.ToLower()} = new {_selectedEnumeratorType}<>(); \r\n"
                    + str[1].Substring(1);
            }

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

        public DelegateCommand OkButtonClickedCommand { get; private set; }

        private void OnOkButtonClicked()
        {
            (_gtLibClassModel.ListOfLibClasses.Find(m => m.Name == SelectedClass)).Text = SelectedClassText;
            RaiseOkButtonClicked();
        }

        public event EventHandler OkButtonClicked;

        private void RaiseOkButtonClicked()
        {
            OkButtonClicked?.Invoke(this, new EventArgs());
        }
    }
}
