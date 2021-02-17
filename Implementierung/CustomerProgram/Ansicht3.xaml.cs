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
            parent.View3Confirm();
        }
    }
}
