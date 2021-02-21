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
using System.Windows.Controls.Primitives;

namespace Tischreservierung_Customer
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ansicht1 A1;
        Ansicht2 A2;
        Ansicht3 A3;

        string _SelectedRestaurantName = "";
        public string SelectedRestaurantName {
            get { return _SelectedRestaurantName; }
            set {
                _SelectedRestaurantName = value;
            } }

        int _NumberOfPeople = 0;
        public int NumberOfPeople
        {
            get { return _NumberOfPeople; }
            set { _NumberOfPeople = value; }
        }

        int _SelectedTableID = 0;
        public int SelectedTableID
        {
            get { return _SelectedTableID; }
            set { _SelectedTableID = value; }
        }


        public TimeSpan StartTime;
        public TimeSpan EndTime;

        public DBContext ctx;

        public MainWindow()
        {
            ctx = new DBContext();

            A1 = new Ansicht1(this, ctx);
            A2 = new Ansicht2(this);
            A3 = new Ansicht3(this);      

            InitializeComponent();

            ContentC.Content = A1;
        }

        public void ViewCancel()
        {
            ContentC.Content = A1;
        }

        public void View1Confirm()
        {
            SelectedRestaurantName = A1.GetRestaurant();
            NumberOfPeople = A1.GetNumberOfPeople();
            StartTime = A1.GetStartTime();
            EndTime = A1.GetEndTime();
            if (SelectedRestaurantName == "")
            {

                return;
            }
            if (NumberOfPeople == 0)
            {

                return;
            }
            if (StartTime == null)
            {

                return;
            }
            if (EndTime == null)
            {

                return;
            }
            A2.FillSelection();
            ContentC.Content = A2;
        }

        public void View2Back()
        {

            ContentC.Content = A1;
        }


        public void View2Select(int tableIndex)
        {
            SelectedTableID = tableIndex;
            ContentC.Content = A3;
        }

        public void View3Back()
        {

            ContentC.Content = A2;
        }


        public void View3Confirm(string name, string phonenumber, string email)
        {
            Customer c = new Customer();
            c.Name = name;
            c.Phonenumber = phonenumber;
            c.Email = email;

            ctx.Customer.Add(c);

            Reservation r = new Reservation();
            r.Customer = c;
            r.TableID = SelectedTableID;
            r.NumberOfPeople = NumberOfPeople;
            r.StartPoint = DateTime.Today + StartTime;
            r.EndePoint = DateTime.Today + EndTime;

            ctx.Reservation.Add(r);

            ctx.SaveChanges();

            MessageBox.Show($"Thank you for your reservation!\n ReservationID: {r.ReservationID}");

            ViewCancel();

        }

    }
}
