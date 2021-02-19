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
    /// Interaktionslogik für Ansicht2.xaml
    /// </summary>
    public partial class Ansicht2 : UserControl
    {
        MainWindow parent;
        public Ansicht2(MainWindow parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        public void FillTables()
        {
            int RestaurantID = parent.ctx.Restaurant.First(x => x.Name == parent.SelectedRestaurantName).RestaurantID;
            var Tische = parent.ctx.Tisch;

            TischListBox.Items.Clear();

            foreach (Tisch t in Tische)
            {
                if (t.RestaurantID == RestaurantID)
                {
                    ListBoxItem l = new ListBoxItem();
                    TextBlock te = new TextBlock();
                    te.Text = $"ID: {t.TableID}  TableSize: {t.TableSize}";
                    l.Content = te;

                    if (t.TableSize < parent.NumberOfPeople)
                    {
                        l.Background = Brushes.Red;
                    }
                    else
                    {
                        foreach(Reservation r in parent.ctx.Reservation)
                        {
                            if(r.TableID == t.TableID)
                            {
                                TimeSpan rStart = TimeSpan.FromMinutes(r.StartPoint.Hour*60 + r.StartPoint.Minute);
                                TimeSpan rEnd = TimeSpan.FromMinutes(r.EndePoint.Hour * 60 + r.EndePoint.Minute);

                                if (rStart < parent.StartTime && rEnd > parent.StartTime)
                                {
                                    l.Background = Brushes.Red;
                                }
                                else
                                {
                                    if (rStart > parent.StartTime && rStart < parent.EndTime)
                                    {
                                        l.Background = Brushes.Red;
                                    }
                                }
                            }
                        }
                    }


                    TischListBox.Items.Add(l);

                }
            }
        }

        public void FillSelection()
        {
            RestaurantHeader.Text = parent.SelectedRestaurantName;
            NOPTextBox.Text = parent.NumberOfPeople.ToString();

            FillTables();
            
            StartTextBox.Text = parent.StartTime.ToString();
            EndTextBox.Text = parent.EndTime.ToString();

        }

        public int GetSelectedTable()
        {
            return TischListBox.SelectedIndex + 1;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            parent.View2Back();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            parent.ViewCancel();
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            int tableIndex = GetSelectedTable();

            if (tableIndex != null)
            {
                parent.View2Select(tableIndex);
            }
        }
    }
}
