using System.Windows;
using GtLibHelper.GtLibClasses.Implementable;
using GtLibHelper.View;

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

        private void Selection_Click(object sender, RoutedEventArgs e)
        {
            OneParamClassesWindow secondWindow = new OneParamClassesWindow();

            secondWindow.setMainTextBox("az osztaly \n\rleiro cuc\n\rca");

            secondWindow.ShowDialog();
        }

        private void Enumerator_Click(object sender, RoutedEventArgs e)
        {
            OneParamClassesWindow secondWindow = new OneParamClassesWindow();

            secondWindow.setMainTextBox("az osztaly \n\rleiro cuc\n\rca");

            secondWindow.ShowDialog();

        }

        private void Counting_Click(object sender, RoutedEventArgs e)
        {
            OneParamClassesWindow secondWindow = new OneParamClassesWindow();

            secondWindow.setMainTextBox("az osztaly \n\rleiro cuc\n\rca");

            secondWindow.ShowDialog();
        }

        private void Summnation_Click(object sender, RoutedEventArgs e)
        {
            TwoParamClassesWindow secondWindow = new TwoParamClassesWindow();

            secondWindow.ShowDialog();
        }
    }
}
