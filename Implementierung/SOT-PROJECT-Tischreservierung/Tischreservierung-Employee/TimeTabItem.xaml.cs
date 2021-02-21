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
    public partial class TimeTabItem : UserControl
    {
        DBContext ctx;

        int SelectedRestaurant = 0;

        Dictionary<int, ListBoxItem> ListBoxItems = new Dictionary<int, ListBoxItem>();
        public TimeTabItem(DBContext ctx)
        {
            this.ctx = ctx;

            InitializeComponent();
        }

        private bool CheckReservationTime(int ReservationID)
        {
            DateTime? PickerTime = TimePicker.Value;
            if(PickerTime != null)
            {
                Reservation selectedReservation = ctx.Reservation.First(x => x.ReservationID == ReservationID);

                if(selectedReservation.StartPoint.CompareTo(PickerTime) <= 0 && selectedReservation.EndePoint.CompareTo(PickerTime) >= 0)
                {
                    return true;
                }
            }   
            else
            {
                return true;
            }
            return false;    
        }

        public void FillListBox()
        {
            TimeListBox.Items.Clear();
            ListBoxItems.Where(x => CheckReservationTime(x.Key)).ToList().ForEach(x => TimeListBox.Items.Add(x.Value));

        }

        public void UpdateListBox(int SelectedRestaurant)
        {
            ListBoxItems.Clear();
            this.SelectedRestaurant = SelectedRestaurant;
            if (SelectedRestaurant != 0)
            {

                foreach (Reservation r in ctx.Reservation)
                {
                    if (r.Table.RestaurantID == SelectedRestaurant)
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


        private void TimePicker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            FillListBox();
        }
    }
}
