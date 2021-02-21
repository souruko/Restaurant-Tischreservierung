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

namespace Tischreservierung_Employee
{
    /// <summary>
    /// Interaktionslogik für TableTabItem.xaml
    /// </summary>
    public partial class ReservationTabItem : UserControl
    {
        DBContext ctx;

        int SelectedRestaurant = 0;

        Dictionary<int, ListBoxItem> LBItems = new Dictionary<int, ListBoxItem>();
        public ReservationTabItem(DBContext ctx)
        {
            this.ctx = ctx;

            InitializeComponent();
        }

        public void FillListBox()
        {
            string txt = FilterTB.Text;
            ReservatischLB.Items.Clear();
            LBItems.Where(x => x.Key.ToString().Contains(txt)).ToList().ForEach(x => ReservatischLB.Items.Add(x.Value));


        }

        public void UpdateLB(int SelectedRestaurant)
        {

            LBItems.Clear();
            this.SelectedRestaurant = SelectedRestaurant;
            if (SelectedRestaurant != 0)
            {

                foreach (Reservation r in ctx.Reservation)
                {
                    if (r.Tisch.RestaurantID == SelectedRestaurant)
                    {
                        ListBoxItem i = new ListBoxItem();
                        TextBlock tb = new TextBlock();
                        tb.Text = $"ID: {r.ReservationID},  Number of People: {r.NumberOfPeople}, Table: {r.TableID}, Customer: {r.Customer.Name}, Start: {r.StartPoint}, End: {r.EndePoint}";
                        i.Content = tb;
                        LBItems.Add(r.ReservationID, i);

                    }
                }

                FillListBox();
            }
        }

        private void FilterTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillListBox();
        }
    }
}
