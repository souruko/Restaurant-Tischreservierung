using System;
using System.IO;
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
    public partial class TableTabItem : UserControl
    {
        DBContext ctx;

        int SelectedRestaurant = 0;

        Dictionary<int, ListBoxItem> LBItems = new Dictionary<int, ListBoxItem>();
        public TableTabItem(DBContext ctx)
        {
            this.ctx = ctx;

            InitializeComponent();
        }

        public void FillListBox()
        {
            string txt = FilterTB.Text;
            TableLB.Items.Clear();
            LBItems.Where(x => x.Key.ToString().Contains(txt)).ToList().ForEach(x => TableLB.Items.Add(x.Value));


        }

        public void UpdateLB(int SelectedRestaurant)
        {

            LBItems.Clear();
            this.SelectedRestaurant = SelectedRestaurant;
            if (SelectedRestaurant != 0)
            {

                foreach (Tisch t in ctx.Tisch)
                {
                    if (t.RestaurantID == SelectedRestaurant)
                    {
                        ListBoxItem i = new ListBoxItem();
                        TextBlock tb = new TextBlock();
                        tb.Text = $"ID: {t.TableID}  TableSize: {t.TableSize}";
                        i.Content = tb;
                        LBItems.Add(t.TableID, i);

                    }
                }

                FillListBox();
            }
        }

        private void UpdateReservationLB(int TableID)
        {
            foreach(Reservation r in ctx.Reservation)
            {
                if(r.TableID == TableID)
                {
                    ListBoxItem i = new ListBoxItem();
                    TextBlock tb = new TextBlock();
                    tb.Text = $"ID: {r.ReservationID},  Number of People: {r.NumberOfPeople}, Table: {r.TableID}, Customer: {r.Customer.Name}, Start: {r.StartPoint}, End: {r.EndePoint}";
                    i.Content = tb;
                    ReservationLB.Items.Add(i);
                }
            }
        }

        private void FilterTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillListBox();
        }

        private void TableLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ReservationLB.Items.Clear();

            if (TableLB.SelectedItem != null)
            {
                int index = LBItems.First(x => x.Value == TableLB.Items.GetItemAt(TableLB.SelectedIndex)).Key;

                UpdateReservationLB(index);
            }
        }
    }
}
