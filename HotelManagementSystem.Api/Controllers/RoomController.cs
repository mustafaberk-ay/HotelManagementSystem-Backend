using HotelManagementSystem.Business.Abstracts;
using HotelManagementSystem.Business.Services;
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
        [HttpPost]
        public IActionResult Create(RoomViewModel viewModel)
        {
            if (_roomService.Create(viewModel))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult Update(int id, RoomViewModel viewModel)
        {
            if (_roomService.Update(id, viewModel))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (_roomService.Delete(id))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult CheckIn(int roomId)
        {
            if (_roomService.CheckIn(roomId))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult CheckOut(int roomId)
        {
            if (_roomService.CheckOut(roomId))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
