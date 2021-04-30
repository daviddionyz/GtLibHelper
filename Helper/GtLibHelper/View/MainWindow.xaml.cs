using GtLibHelper.GtLibClasses;
using GtLibHelper.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using WPF.JoshSmith.ServiceProviders.UI;

namespace GtLibHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {

        private ListViewDragDropManager<AbstractLibClass> lvddm;

        public MainWindow()
        {
            InitializeComponent();
            lvddm = new ListViewDragDropManager<AbstractLibClass>(ListView);
        }

        private string SourceClassName { get; set; }
        private string DestinationClassName { get; set; }

        private void ListView_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ListViewItem item = ListView.ContainerFromElement(ListView, e.OriginalSource as DependencyObject) as ListViewItem;
            if (item != null) 
            {
                SourceClassName = (item.Content as AbstractLibClass).Name;
                
            }
        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            ListViewItem item = ListView.ContainerFromElement(ListView, e.OriginalSource as DependencyObject) as ListViewItem;
            if (item != null) 
            {
                DestinationClassName = (item.Content as AbstractLibClass).Name;
                (this.DataContext as MainWindowViewModel).DragAndDropClassManager(SourceClassName, DestinationClassName);
                SourceClassName = null;
                DestinationClassName = null;
            }
        }

    }
}
