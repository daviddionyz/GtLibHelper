using GtLibHelper.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.ViewModel
{
    public class OwnStructViewModel : ViewModelBase
    {
        private String _feedBackText;
        private String _className;
        private String _classText;
        private String _item;
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

        private bool Ok { get; set; }


        public DelegateCommand OkButtonClickedCommand { get; private set; }

        public OwnStructViewModel(GtLibClassModel model)
        {
            _gtLibClassModel = model;

            OkButtonClickedCommand = new DelegateCommand(param => OnOkButtonClicked());

            ClassText = model.CurrentLibClass.Text;

            Ok = false;
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

            _gtLibClassModel.RefreshLibClassData(ClassName, null, null, null, ClassText);
            _gtLibClassModel.CurrentLibClass.RefreshText();

            ClassText = _gtLibClassModel.CurrentLibClass.Text;
        }

    }
}
