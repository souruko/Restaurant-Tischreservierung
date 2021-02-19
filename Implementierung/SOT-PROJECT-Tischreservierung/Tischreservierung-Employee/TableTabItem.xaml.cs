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

        Dictionary<int, ListBoxItem> Items = new Dictionary<int, ListBoxItem>();
        public TableTabItem(DBContext ctx)
        {
            this.ctx = ctx;

            InitializeComponent();
        }

        public void FillListBox()
        {
            foreach(ListBoxItem i in Items)
            {
                
            }
        }

        public void Open()
        {
            TableLB.Items.Clear();
            Items.Clear();

            foreach(Tisch t in ctx.Tisch)
            {
                ListBoxItem i = new ListBoxItem();
                TextBlock tb = new TextBlock();
                tb.Text = $"{t.TableID}";
                i.Content = tb;

                Items.Add(t.TableID ,i);
            }
    }
}
