using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tischreservierung
{
    public class Reservation
    {
        static public int NextReservationID = 1;
        public int NumberOfPeople { get; }
        public DateTime Start { get; }
        public DateTime End { get; }
        public Customer CustomerDetails { get; }
        public int ReservationID { get; }

        public Reservation(int NumberOfPeople, DateTime Start, DateTime End, Customer CustomerDetails)
        {
            this.NumberOfPeople = NumberOfPeople;
            this.Start = Start;
            this.End = End;
            this.CustomerDetails = CustomerDetails;
            this.ReservationID = NextReservationID;
            NextReservationID++;
        }

    }
}
