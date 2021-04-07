using GtLibHelper.GtLibClasses;
using GtLibHelper.OwnEventArgs;
using GtLibHelper.View;
using GtLibHelper.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.Services
{
    public class ParamClassWindowService
    {
        private OneParamClassesWindow _oneParamClassesWindow;
        private TwoParamClassesWindow   _twoParamClassesWindow;
        private ThreeParamClassesWindow _threeParamClassesWindow;

        public ParamClassWindowService()
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
        }

    }
}
