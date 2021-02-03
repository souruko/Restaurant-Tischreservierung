using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tischreservierung
{
    public class Table
    {
        public int TableSize { get; }

        public int TableID { get; }

        private List<Reservation> Reservations = new List<Reservation>();

        public Table(int TableSize, int TableID)
        {
            this.TableID = TableID;
            this.TableSize = TableSize;
        }

        public bool Available(DateTime start, DateTime end)
        {
            return false;
        }

        public bool IsReserverd()
        {
            return false;
        }

        public List<Reservation> AllReservations()
        {
            return Reservations;
        }

        public Reservation NextReservationAfter(DateTime time)
        {
            return null;
        }

        public bool AddReservation(Reservation r)
        {
            return false;
        }

        public bool CancelReservation(Reservation r)
        {
            return false;
        }

    }
}
