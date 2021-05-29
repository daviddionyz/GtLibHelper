using GtLibHelper.Services;
using System;

namespace GtLibHelper.ViewModel
{
    public class OwnStructViewModel : ViewModelBase
    {
        #region Fields
        private String _feedBackText;
        private String _className;
        private String _classText;
        private GtLibClassModel _gtLibClassModel;
        #endregion

        #region Properties
        /// <summary>
        /// Current class name
        /// </summary>
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
        /// <summary>
        /// Current class body
        /// </summary>
        public String ClassText
        {
            get { return _classText; }
            set
            {
                _classText = value;
                OnPropertyChanged("ClassText");
            }
        }
        /// <summary>
        /// Feed back text to user
        /// </summary>
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
        #endregion

        #region Delegate Commands 
        public DelegateCommand OkButtonClickedCommand { get; private set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Connect deleget command with methods and initial class text 
        /// </summary>
        /// <param name="model">GtLibClass model with list of gtlib classes</param>
        public OwnStructViewModel(GtLibClassModel model)
        {
            _gtLibClassModel = model;

            OkButtonClickedCommand = new DelegateCommand(param => OnOkButtonClicked());

            ClassText = model.CurrentLibClass.Text;

            Ok = false;
        }
        #endregion

        #region Events and event handlers
        public event EventHandler OkButtonClicked;
        /// <summary>
        /// Add current lib class to the list and invoke ok button clicked event
        /// </summary>
        private void OnOkButtonClicked()
        {
            if (Ok)
            {
                _gtLibClassModel.AddCurrentLibClass();
                OkButtonClicked?.Invoke(this, new EventArgs());
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Check if the current given class name is good and free
        /// </summary>
        private void CheckTheClassName()
        {
            (bool, String) tupel = _gtLibClassModel.CheckTheClassName(ClassName);

            FeedBackText = tupel.Item2;
            Ok = tupel.Item1;
        }
        /// <summary>
        /// Refresh class text(body) with the given properties
        /// </summary>
        private void RefreshClassText()
        {
            _gtLibClassModel.RefreshLibClassData(ClassName, null, null, null, ClassText);

            ClassText = _gtLibClassModel.CurrentLibClass.Text;
        }
        #endregion

    }
}
