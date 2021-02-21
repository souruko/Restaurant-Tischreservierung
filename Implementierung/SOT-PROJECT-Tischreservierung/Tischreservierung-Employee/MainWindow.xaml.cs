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
        CustomerTabItem CTab;
        TableTabItem TaTab;
        TimeTabItem TiTab;
        ReservationTabItem RTab;

        int SelectedRestaurant = 0;


        DBContext ctx;
        private ICollectionView CollectionView;

        public MainWindow()
        {
            ctx = new DBContext();
            InitializeComponent();

            CTab = new CustomerTabItem(ctx);
            TaTab = new TableTabItem(ctx);
            TiTab = new TimeTabItem(ctx);
            RTab = new ReservationTabItem(ctx);

            CustomerTab.Content = CTab;
            TableTab.Content = TaTab;
            ReservationTab.Content = RTab;
            TimeTab.Content = TiTab;

            TiTab.UpdateListBox(SelectedRestaurant);
            RTab.UpdateListBox(SelectedRestaurant);
            TaTab.UpdateListBox(SelectedRestaurant);
            CTab.UpdateListBox(SelectedRestaurant);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ctx.Restaurant.Load();
            CollectionView = CollectionViewSource.GetDefaultView(ctx.Restaurant.Local);
            ParentGrid.DataContext = CollectionView;

        }

        private void RestaurantName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedRestaurant = RestaurantName.SelectedIndex + 1;
            TaTab.UpdateListBox(SelectedRestaurant);
            RTab.UpdateListBox(SelectedRestaurant);
            TiTab.UpdateListBox(SelectedRestaurant);
        }
    }
}
