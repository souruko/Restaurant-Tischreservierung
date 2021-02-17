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
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ansicht1 A1;
        Ansicht2 A2;
        Ansicht3 A3;

        string SelectedRestaurantName = "";


        int NumberOfPeople = 0;
        DateTime StartTime;
        DateTime EndTime;

        DBContext ctx;

        public MainWindow()
        {
            A1 = new Ansicht1(this);
            A2 = new Ansicht2(this);
            A3 = new Ansicht3(this);

            ctx = new DBContext();

            InitializeComponent();

            foreach(Restaurant re in ctx.Restaurant)
            {
                ComboBoxItem c = new ComboBoxItem();
                c.Content = re.Name;
                A1.RestaurantSelection.Items.Add(c);
            }

            ContentC.Content = A1;
        }

        public void ViewCancel()
        {
            ContentC.Content = A1;
        }

        public void View1Confirm()
        {
            //if(SelectedRestaurantID == 0)
            //{

            //    return;
            //}
            //if (NumberOfPeople == 0)
            //{

            //    return;
            //}
            //if (StartTime == null)
            //{

            //    return;
            //}
            //if (EndTime == null)
            //{

            //    return;
            //}

            ContentC.Content = A2;
        }

        public void View2Back()
        {

            ContentC.Content = A1;
        }


        public void View2Select()
        {
            ContentC.Content = A3;
        }

        public void View3Back()
        {

            ContentC.Content = A2;
        }


        public void View3Confirm()
        {

        }

    }
}
