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

namespace Tablereservation_Employee
{
    /// <summary>
    /// Interaktionslogik für TableTabItem.xaml
    /// </summary>
    public partial class ReservationTabItem : UserControl
    {
        DBContext ctx;

        int SelectedRestaurant = 0;

        Dictionary<int, ListBoxItem> ListBoxItems = new Dictionary<int, ListBoxItem>();
        public ReservationTabItem(DBContext ctx)
        {
            this.ctx = ctx;

            InitializeComponent();
        }

        public void FillListBox()
        {
            string txt = FilterTextBox.Text;
            ReservatableListBox.Items.Clear();
            ListBoxItems.Where(x => x.Key.ToString().Contains(txt)).ToList().ForEach(x => ReservatableListBox.Items.Add(x.Value));
            

        }

        public void UpdateListBox(int SelectedRestaurant)
        {

            ListBoxItems.Clear();
            this.SelectedRestaurant = SelectedRestaurant;
            if (SelectedRestaurant != 0)
            {

                foreach (Reservation r in ctx.Reservation)
                {
                    if (r.Tisch.RestaurantID == SelectedRestaurant)
                    {
                        ListBoxItem lbi = new ListBoxItem();
                        TextBlock tb = new TextBlock();
                        tb.Text = $"ID: {r.ReservationID},  Number of People: {r.NumberOfPeople}, Table: {r.TableID}, Customer: {r.Customer.Name}, Start: {r.StartPoint}, End: {r.EndePoint}";
                        lbi.Content = tb;
                        ListBoxItems.Add(r.ReservationID, lbi);

                    }
                }

                FillListBox();
            }
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillListBox();
        }
    }
}
