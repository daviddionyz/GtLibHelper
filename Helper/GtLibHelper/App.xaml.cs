using GtLibHelper.Services;
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
        private MainWindowViewModel _viewModel;
        private MainWindow _mainWindow;
        private GtLibClassModel _gtLibClassModel;

        public App(){
            _gtLibClassModel = new GtLibClassModel();

            //view model part
            _viewModel = new MainWindowViewModel(_gtLibClassModel);

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
