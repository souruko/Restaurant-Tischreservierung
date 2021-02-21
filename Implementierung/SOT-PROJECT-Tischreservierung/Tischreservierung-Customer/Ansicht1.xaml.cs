using System;
using System.Collections.Generic;
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

using System.ComponentModel;
using System.Data.Entity;

namespace Tischreservierung_Customer
{
    /// <summary>
    /// Interaktionslogik für Ansicht1.xaml
    /// </summary>
    public partial class Ansicht1 : UserControl
    {
        private ICollectionView CollectionView;
        MainWindow parent;
        DBContext ctx;



        public Ansicht1(MainWindow parent, DBContext ctx)
        {
            this.parent = parent;
            this.ctx = ctx;


            InitializeComponent();

            for (int i = 1; i < 20; i++)
            {
                ComboBoxItem c = new ComboBoxItem();
                c.Content = i;

                NumberOfPeopleBox.Items.Add(c);
            }

        }

        public TimeSpan GetStartTime()
        {
            return TimeSpan.Parse(StartComboBox.Text);
        }

        public TimeSpan GetEndTime()
        {
            return TimeSpan.Parse(EndComboBox.Text);
        }


        public int GetNumberOfPeople()
        {
            return NumberOfPeopleBox.SelectedIndex + 1;
        }

        public string GetRestaurant()
        {
            if (RestaurantNameComboBox.SelectedItem != null)
                return RestaurantNameComboBox.Text;
            else
                return "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            parent.View1Confirm();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ctx.Restaurant.Load();
            CollectionView = CollectionViewSource.GetDefaultView(ctx.Restaurant.Local);
            ParentGrid.DataContext = CollectionView;

        }

        private void RestaurantNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StartComboBox.Items.Clear();
            EndComboBox.Items.Clear();

            if (RestaurantNameComboBox.SelectedItem != null)
            {
                Restaurant Rest = ctx.Restaurant.First(x => x.RestaurantID == RestaurantNameComboBox.SelectedIndex+1);

                TimeSpan viertelStunde = TimeSpan.FromMinutes(15);
                var Counter = Rest.OpenTime.Value;
                var Ende = Rest.CloseTime.Value;

                while (Counter < Ende)
                {
                    ComboBoxItem i = new ComboBoxItem();
                    i.Content = Counter;


                    StartComboBox.Items.Add(i);
                    Counter += viertelStunde;
                }

                Counter = Rest.OpenTime.Value+viertelStunde;
                while (Counter <= Ende)
                {
                    ComboBoxItem i = new ComboBoxItem();
                    i.Content = Counter;


                    EndComboBox.Items.Add(i);
                    Counter += viertelStunde;
                }

            }
        }
    }
}
