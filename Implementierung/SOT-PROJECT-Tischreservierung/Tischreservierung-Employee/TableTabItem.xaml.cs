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

        Dictionary<int, ListBoxItem> ListBoxItems = new Dictionary<int, ListBoxItem>();
        public TableTabItem(DBContext ctx)
        {
            this.ctx = ctx;

            InitializeComponent();
        }

        public void FillListBox()
        {
            string txt = FilterTextBox.Text;
            TableListBox.Items.Clear();
            ListBoxItems.Where(x => x.Key.ToString().Contains(txt)).ToList().ForEach(x => TableListBox.Items.Add(x.Value));


        }

        public void UpdateLB(int SelectedRestaurant)
        {

            ListBoxItems.Clear();
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
                        ListBoxItems.Add(t.TableID, i);

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
                    ReservationListBox.Items.Add(i);
                }
            }
        }

        private void FilterTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillListBox();
        }

        private void TableLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ReservationListBox.Items.Clear();

            if (TableListBox.SelectedItem != null)
            {
                int index = ListBoxItems.First(x => x.Value == TableListBox.Items.GetItemAt(TableListBox.SelectedIndex)).Key;

                UpdateReservationLB(index);
            }
        }
    }
}
