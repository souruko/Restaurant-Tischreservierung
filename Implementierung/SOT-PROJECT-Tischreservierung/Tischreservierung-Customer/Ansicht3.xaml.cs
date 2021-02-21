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

namespace Tischreservierung_Customer
{
    /// <summary>
    /// Interaktionslogik für Ansicht3.xaml
    /// </summary>
    public partial class Ansicht3 : UserControl
    {
        MainWindow parent;
        public Ansicht3(MainWindow parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        public void FillSummary(string RestaurantName, int TableID, int NumberOfPeople, TimeSpan StartPoint, TimeSpan EndPoint)
        {
            SummaryTB.Text = $"Restaurant: {RestaurantName}\nTable: {TableID}\nNumber of People: {NumberOfPeople}\nTime: {StartPoint} - {EndPoint}";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            parent.View3Back();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            parent.ViewCancel();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTB.Text;
            string phoneNumber = PhoneNumberTB.Text;
            string email = EmailTB.Text;

            if(name == "" || phoneNumber == "" )
            {
                return;
            }

            if(email == "")
            {
                email = null;
            }

            parent.View3Confirm(name, phoneNumber, email);
        }
    }
}