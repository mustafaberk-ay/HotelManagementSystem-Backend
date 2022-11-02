using System;
using System.Collections.Generic;

namespace HotelManagementSystem.DataModels.DataModels
{
    public partial class Customer
    {
        public Customer()
        {
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public bool HasReservation { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Country { get; set; } = null!;

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
