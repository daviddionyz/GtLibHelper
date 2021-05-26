using GtLibHelper.OwnEventArgs;
using GtLibHelper.View;
using GtLibHelper.ViewModel;
using System;

namespace GtLibHelper.Services
{
    public class OpenClassWindowService
    {
        #region Fields
        private OneParamClassesWindow _oneParamClassesWindow;
        private TwoParamClassesWindow _twoParamClassesWindow;
        private ThreeParamClassesWindow _threeParamClassesWindow;
        private OwnStructWindow _ownStructWindow;
        private EnumeratorsWindow _enumeratorsWindow;
        #endregion

        #region Constructors
        public OpenClassWindowService()
        {

        }
        #endregion

        #region Window openers methods
        /// <summary>
        /// Open OneParamwindow and give the model to it
        /// </summary>
        /// <param name="model">gtLib class model</param>
        public void OpenOneParamWindow(GtLibClassModel model)
        {

            if (model.CurrentLibClass != null)
            {
                _oneParamClassesWindow = new OneParamClassesWindow();
                OneParamViewModel oneParamViewModel = new OneParamViewModel(model);

                _oneParamClassesWindow.DataContext = oneParamViewModel;

                oneParamViewModel.OkButtonClicked += OkButtonClicked_Handler;

                _oneParamClassesWindow.ShowDialog();
            }
        }
        /// <summary>
        /// Open TwoParamWindow and give the model to it
        /// </summary>
        /// <param name="model">gtLib class model</param>
        public void OpenTwoParamWindow(GtLibClassModel model)
        {
            if (model.CurrentLibClass != null)
            {
                _twoParamClassesWindow = new TwoParamClassesWindow();
                TwoParamViewModel twoParamViewModel = new TwoParamViewModel(model);

                _twoParamClassesWindow.DataContext = twoParamViewModel;

                twoParamViewModel.OkButtonClicked += OkButtonClicked_Handler;

                _twoParamClassesWindow.ShowDialog();
            }
        }
        /// <summary>
        /// Open ThreeParamWindow and give the model to it
        /// </summary>
        /// <param name="model">gtLib class model</param>
        public void OpenThreeParamWindow(GtLibClassModel model)
        {
            _threeParamClassesWindow = new ThreeParamClassesWindow();
            ThreeParamViewModel threeParamViewModel = new ThreeParamViewModel(model);

            _threeParamClassesWindow.DataContext = threeParamViewModel;

            threeParamViewModel.OkButtonClicked += OkButtonClicked_Handler;

            _threeParamClassesWindow.ShowDialog();
        }
        /// <summary>
        /// Open OwnStructWindow and give the model to it
        /// </summary>
        /// <param name="model">gtLib class model</param>
        public void OpenOwnStructWindow(GtLibClassModel model)
        {
            _ownStructWindow = new OwnStructWindow();
            OwnStructViewModel ownStructViewModel = new OwnStructViewModel(model);

            _ownStructWindow.DataContext = ownStructViewModel;

            ownStructViewModel.OkButtonClicked += OkButtonClicked_Handler;

            _ownStructWindow.ShowDialog();
        }
        /// <summary>
        /// Open EnumeratorsWindow and give the model to it and selected enumerator type
        /// </summary>
        /// <param name="model">gtLib class model</param>
        /// <param name="selectedEnumeratorType">selected enumerator type</param>
        public void OpenEnumeratorsWindow(GtLibClassModel model, String selectedEnumeratorType)
        {
            _enumeratorsWindow = new EnumeratorsWindow();
            EnumeratorsWindowViewModel enumeratorsWindowViewModel = new EnumeratorsWindowViewModel(model, selectedEnumeratorType);

            _enumeratorsWindow.DataContext = enumeratorsWindowViewModel;

            enumeratorsWindowViewModel.OkButtonClicked += OkButtonClicked_Handler;
            enumeratorsWindowViewModel.EnumeratorCalssCreated += EnumeratorClassCreated_Handler;

            _enumeratorsWindow.ShowDialog();
        }
        /// <summary>
        /// Open DeleteClassWindow and give the model to it
        /// </summary>
        /// <param name="model">gtLib class model</param>
        public void OpenDeleteClassWindow(GtLibClassModel model)
        {
            DeleteClassWindow deleteClassWindow = new DeleteClassWindow();
            DeleteClassViewModel deleteClassViewModel = new DeleteClassViewModel(model);

            deleteClassWindow.DataContext = deleteClassViewModel;

            deleteClassWindow.ShowDialog();
        }
        #endregion

        #region Events and Event handlers
        public event EventHandler ClassGenerated;
        public event EventHandler<EnumeratorCreatedEventArgs> EnumeratorClassCreated;

        /// <summary>
        /// If on the opened window ok button was clicked then this handels it and close the window
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void OkButtonClicked_Handler(object sender, EventArgs e)
        {
            if (_oneParamClassesWindow != null)
            {
                _oneParamClassesWindow.Close();
                _oneParamClassesWindow = null;

            }
            else if (_twoParamClassesWindow != null)
            {
                _twoParamClassesWindow.Close();
                _twoParamClassesWindow = null;
            }
            else if (_threeParamClassesWindow != null)
            {
                _threeParamClassesWindow.Close();
                _threeParamClassesWindow = null;
            }
            else if (_ownStructWindow != null)
            {
                _ownStructWindow.Close();
                _ownStructWindow = null;
            }
            else if (_enumeratorsWindow.IsActive)
            {
                _enumeratorsWindow.Close();
                _enumeratorsWindow = null;
            }

            Raise_ClassGeneratedEvent();
        }
        /// <summary>
        /// Invokde Class generated event
        /// </summary>
        private void Raise_ClassGeneratedEvent()
        {
            ClassGenerated?.Invoke(this, new EventArgs());
        }
        /// <summary>
        /// Handel if enumerator class created on window and invoke enumerator class generated event
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void EnumeratorClassCreated_Handler(object sender, EnumeratorCreatedEventArgs e)
        {
            EnumeratorClassCreated?.Invoke(sender, e);
        }
        #endregion
    }
}
