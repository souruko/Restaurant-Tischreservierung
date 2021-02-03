using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tischreservierung
{
    public class Restaurant
    {
        public string Name { get; }
        private List<Table> Tables = new List<Table>();


        public Restaurant(string Name)
        {
            this.Name = Name;
        }

        public void AddTable(Table t)
        {
            Tables.Add(t);
        }

        public void RemoveTable(Table t)
        {
            Tables.Remove(t);
        }

        public int NumberOfTables()
        {
            return Tables.Count();
        }

        public List<Reservation> AllReservations()
        {
            return null;
        }

        public List<Reservation> DailyReservations(DateTime date)
        {
            return null;
        }

        public List<Table> AvailableTables(DateTime start, DateTime end)
        {
            return null;
        }
    }
}
