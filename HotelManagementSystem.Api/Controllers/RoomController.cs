using HotelManagementSystem.Business.Abstracts;
using HotelManagementSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpGet]
        public RoomViewModel Get(int id)
        {
            return _roomService.Get(id);
        }
        [HttpGet]
        public List<RoomViewModel> GetAll()
        {
            return _roomService.GetAll();
        }
    }
}
