//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tablereservation_Employee
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reservation
    {
        public int ReservationID { get; set; }
        public int NumberOfPeople { get; set; }
        public System.DateTime StartPoint { get; set; }
        public System.DateTime EndePoint { get; set; }
        public int CustomerID { get; set; }
        public int TableID { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Tisch Tisch { get; set; }
    }
}
