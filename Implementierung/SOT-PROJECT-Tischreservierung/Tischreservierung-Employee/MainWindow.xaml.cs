using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tischreservierung_Employee
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBContext ctx;
        private ICollectionView CollectionView;

        public MainWindow()
        {
            ctx = new DBContext();
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ctx.Restaurant.Load();
            CollectionView = CollectionViewSource.GetDefaultView(ctx.Restaurant.Local);
            ParentGrid.DataContext = CollectionView;

        }
    }
}
