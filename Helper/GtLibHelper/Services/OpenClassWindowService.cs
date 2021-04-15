using GtLibHelper.GtLibClasses;
using GtLibHelper.OwnEventArgs;
using GtLibHelper.View;
using GtLibHelper.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.Services
{
    public class OpenClassWindowService
    {
        private OneParamClassesWindow _oneParamClassesWindow;
        private TwoParamClassesWindow _twoParamClassesWindow;
        private ThreeParamClassesWindow _threeParamClassesWindow;
        private OwnStructWindow _ownStructWindow;
        private EnumeratorsWindow _enumeratorsWindow;

        public OpenClassWindowService()
        {
            
        }

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
        public void OpenThreeParamWindow(GtLibClassModel model)
        {
            _threeParamClassesWindow = new ThreeParamClassesWindow();
            ThreeParamViewModel threeParamViewModel = new ThreeParamViewModel(model);

            _threeParamClassesWindow.DataContext = threeParamViewModel;

            threeParamViewModel.OkButtonClicked += OkButtonClicked_Handler;

            _threeParamClassesWindow.ShowDialog();
        }
        public void OpenOwnStructWindow(GtLibClassModel model)
        {
            _ownStructWindow = new OwnStructWindow();
            OwnStructViewModel ownStructViewModel = new OwnStructViewModel(model);

            _ownStructWindow.DataContext = ownStructViewModel;

            ownStructViewModel.OkButtonClicked += OkButtonClicked_Handler;

            _ownStructWindow.ShowDialog();
        }
        public void OpenEnumeratorsWindow(GtLibClassModel model, String selectedEnumeratorType) 
        {
            _enumeratorsWindow = new EnumeratorsWindow();
            EnumeratorsWindowViewModel enumeratorsWindowViewModel = new EnumeratorsWindowViewModel(model, selectedEnumeratorType);

            _enumeratorsWindow.DataContext = enumeratorsWindowViewModel;

            enumeratorsWindowViewModel.OkButtonClicked += OkButtonClicked_Handler;

            _enumeratorsWindow.ShowDialog();
        }


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
            } else if (_enumeratorsWindow.IsActive) 
            {
                _enumeratorsWindow.Close();
                _enumeratorsWindow = null;
            }

            Raise_ClassGeneratedEvent();
        }
        public event EventHandler ClassGenerated;
        private void Raise_ClassGeneratedEvent() 
        {
            ClassGenerated?.Invoke(this, new EventArgs());
        }
    }
}
