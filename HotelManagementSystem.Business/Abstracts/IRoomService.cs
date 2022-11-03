using HotelManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Business.Abstracts
{
    public interface IRoomService
    {
        RoomViewModel Get(int id);
        List<RoomViewModel> GetAll();
        bool Create(RoomViewModel viewModel);
        bool Update(int id, RoomViewModel viewModel);
        bool Delete(int id);
        bool CheckIn(int roomId);
        bool CheckOut(int roomId);
    }
}
