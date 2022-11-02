using System;
using System.Collections.Generic;

namespace HotelManagementSystem.DataModels.DataModels
{
    public partial class Room
    {
        public int Id { get; set; }
        public string RoomType { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public bool IsFree { get; set; }
        public int RoomNumber { get; set; }
        public int? ReservedCustomerId { get; set; }

        public virtual Customer? ReservedCustomer { get; set; }
    }
}
