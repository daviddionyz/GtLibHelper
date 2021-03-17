using System.Windows;
using GtLibHelper.GtLibClasses.Implementable;
using GtLibHelper.View;
using GtLibHelper.Model;
using System;

namespace GtLibHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        //private void Selection_Click(object sender, RoutedEventArgs e)
        //{
        //    OneParamClassesWindow secondWindow = new OneParamClassesWindow();

        //    secondWindow.okButtonPushed += okButtonPushed_MainView;

        //    secondWindow.ShowDialog();
        //}


        //private void Enumerator_Click(object sender, RoutedEventArgs e)
        //{
        //    OneParamClassesWindow secondWindow = new OneParamClassesWindow();

        //    secondWindow.okButtonPushed += okButtonPushed_MainView;

        //    secondWindow.ShowDialog();

        //}

        //private void Counting_Click(object sender, RoutedEventArgs e)
        //{
        //    OneParamClassesWindow secondWindow = new OneParamClassesWindow();

        //    Counting dump = new Counting("");

        //    secondWindow.mainText.Text = dump.Text;
        //    secondWindow.okButtonPushed += okButtonPushed_MainView;
        //    secondWindow.name.TextChanged += classNameTextBoxChanged;

        //    secondWindow.ShowDialog();
        //}

        //private void Summnation_Click(object sender, RoutedEventArgs e)
        //{
        //    TwoParamClassesWindow secondWindow = new TwoParamClassesWindow();

        //    secondWindow.okButtonPushed += okButtonPushed_MainView;

        //    secondWindow.ShowDialog();
        //}
        //private void LinSearch_Click(object sender, RoutedEventArgs e)
        //{
        //    TwoParamClassesWindow secondWindow = new TwoParamClassesWindow();

        //    secondWindow.okButtonPushed += okButtonPushed_MainView;

        //    secondWindow.ShowDialog();
        //}

        //private void classNameTextBoxChanged(object sender, EventArgs e) 
        //{
        //    ClassNameChanged?.Invoke(sender,e);
        //}

        //private void okButtonPushed_MainView(object sender, EventArgs e) 
        //{
        //    //todo get out info and reise event
        //}

    }
}
