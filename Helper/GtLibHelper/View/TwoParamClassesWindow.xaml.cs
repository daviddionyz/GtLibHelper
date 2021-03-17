using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GtLibHelper.View
{
    /// <summary>
    /// Interaction logic for TwoParamClassesWindow.xaml
    /// </summary>
    public partial class TwoParamClassesWindow : Window
    {
        //public event EventHandler okButtonPushed;
        public TwoParamClassesWindow()
        {
            InitializeComponent();
        }

        //private void Cancel_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}

        //private void Ok_Click(object sender, RoutedEventArgs e)
        //{
        //    okButtonPushed?.Invoke(this, new EventArgs());
        //}
    }
}
