using GtLibHelper.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GtLibHelper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private GtLibHelperViewModel _viewModel;
        private MainWindow _mainWindow;

        public App(){
            //view model part
            _viewModel = new GtLibHelperViewModel();

            //main window part
            _mainWindow = new MainWindow();
            _mainWindow.DataContext = _viewModel;

            //events handeling part
            _viewModel.Exit += exit_Handler;
            
            _mainWindow.Show();
        }


        private void exit_Handler(Object sender, EventArgs e) 
        {
            _mainWindow.Close();
        }
    }
}
