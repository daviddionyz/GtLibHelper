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
            
        }

        private void Enumerator_Click(object sender, RoutedEventArgs e)
        {
            EnumeratorWindow myEnumWindow = new EnumeratorWindow();

            myEnumWindow.setMainTextBox("az osztaly \n\rleiro cuc\n\rca");

            myEnumWindow.ShowDialog();

        }
    }
}
