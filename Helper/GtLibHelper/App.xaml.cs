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
        private GtLibHelperViewModel viewModel;
        private MainWindow mainWindow;

        public App(){
            //view model part
            viewModel = new GtLibHelperViewModel();

            //main window part
            mainWindow = new MainWindow();

            //events handeling part

            
        }
    }
}
