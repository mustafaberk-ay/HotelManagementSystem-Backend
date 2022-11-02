using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.ViewModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public string RoomType { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public bool IsFree { get; set; }
        public int RoomNumber { get; set; }
        public string? ReservedCustomerFullname { get; set; }
    }
}
