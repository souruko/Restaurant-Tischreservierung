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
    public partial class CustomerTabItem : UserControl
    {
        DBContext ctx;

        int SelectedRestaurant = 0;

        Dictionary<string, ListBoxItem> ListBoxItems = new Dictionary<string, ListBoxItem>();
        public CustomerTabItem(DBContext ctx)
        {
            this.ctx = ctx;

            InitializeComponent();
        }

        public void FillListBox()
        {
            string txt = FilterTextBox.Text;
            CustomerListBox.Items.Clear();
            ListBoxItems.Where(x => x.Key.ToString().Contains(txt)).ToList().ForEach(x => CustomerListBox.Items.Add(x.Value));
        }

        public void UpdateListBox(int SelectedRestaurant)
        {

            ListBoxItems.Clear();
            this.SelectedRestaurant = SelectedRestaurant;

            foreach (Customer c in ctx.Customer)
            {
                ListBoxItem i = new ListBoxItem();
                TextBlock tb = new TextBlock();
                tb.Text = $"Name: {c.Name}, Phonenumber: {c.Phonenumber}, Email: {c.Email} ID: {c.CustomerID}";
                i.Content = tb;
                ListBoxItems.Add(c.Name, i);
            }

            FillListBox();

        }

        private void UpdateReservationListBox(string name)
        {
            foreach (Reservation r in ctx.Reservation)
            {
                if (r.Customer.Name == name)
                {
                    ListBoxItem i = new ListBoxItem();
                    TextBlock tb = new TextBlock();
                    tb.Text = $"ID: {r.ReservationID},  Number of People: {r.NumberOfPeople}, Table: {r.TableID}, Customer: {r.Customer.Name}, Start: {r.StartPoint}, End: {r.EndePoint}";
                    i.Content = tb;
                    ReservationListBox.Items.Add(i);
                }
            }
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillListBox();
        }

        private void CustomerListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ReservationListBox.Items.Clear();

            if (CustomerListBox.SelectedItem != null)
            {
                string name = ListBoxItems.First(x => x.Value == CustomerListBox.Items.GetItemAt(CustomerListBox.SelectedIndex)).Key;

                UpdateReservationListBox(name);
            }
        }
    }
}
