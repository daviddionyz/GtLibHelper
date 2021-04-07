using GtLibHelper.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.ViewModel
{
    public class TwoParamViewModel : ViewModelBase
    {
        private String _feedBackText;
        private String _className;
        private String _classText;
        private String _item;
        private String _t;
        private String _labeForT;

        private GtLibClassModel _gtLibClassModel;

        public String ClassName
        {
            get { return _className; }
            set
            {
                _className = value;
                CheckTheClassName();
                RefreshClassText();
            }
        }
        public String Item
        {
            get { return _item; }
            set
            {
                _item = value;
                RefreshClassText();
            }
        }
        public String T 
        {
            get { return _t; }
            set 
            {
                _t = value;
                RefreshClassText();
            }
        }

        public String ClassText
        {
            get { return _classText; }
            set
            {
                _classText = value;
                OnPropertyChanged("ClassText");
            }
        }
        public String FeedBackText
        {
            get { return _feedBackText; }
            private set
            {
                _feedBackText = value;
                OnPropertyChanged("FeedBackText");
            }
        }
        public String LabelForT 
        {
            get { return _labeForT; }
            private set 
            {
                _labeForT = value;
                OnPropertyChanged("LabeForT");
            }
        }

        private bool Ok { get; set; }

        public DelegateCommand OkButtonClickedCommand { get; private set; }

        public TwoParamViewModel(GtLibClassModel model)
        {
            _gtLibClassModel = model;

            OkButtonClickedCommand = new DelegateCommand(param => OnOkButtonClicked());

            ClassText = model.CurrentLibClass.Text;

            Ok = false;
            if (_gtLibClassModel.CurrentLibClass.Type == "LinSearch")
                LabelForT = "Pleas give it will be optimistic or not.";
            else
                LabelForT = "Please give the type of the T";

        }

        private void OnOkButtonClicked()
        {
            if (Ok)
            {
                _gtLibClassModel.AddCurrentLibClass();
                RaiseOkButtonClicked();
            }
        }

        public event EventHandler OkButtonClicked;

        private void RaiseOkButtonClicked()
        {
            OkButtonClicked?.Invoke(this, new EventArgs());
        }

        private void CheckTheClassName()
        {
            (bool, String) tupel = _gtLibClassModel.CheckTheClassName(ClassName);

            FeedBackText = tupel.Item2;
            Ok = tupel.Item1;
        }

        private void RefreshClassText()
        {

            _gtLibClassModel.RefreshLibClassData(ClassName, Item, T, null, ClassText);
            _gtLibClassModel.CurrentLibClass.RefreshText();

            ClassText = _gtLibClassModel.CurrentLibClass.Text;
        }
    }
}
