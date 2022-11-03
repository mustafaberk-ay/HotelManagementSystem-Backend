using HotelManagementSystem.Business.Abstracts;
using HotelManagementSystem.Business.Services;
using HotelManagementSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpGet]
        public AdminViewModel Get(int id)
        {
            return _adminService.Get(id);
        }
        [HttpGet]
        public List<AdminViewModel> GetAll()
        {
            return _adminService.GetAll();
        }
        [HttpPost]
        public IActionResult Create(AdminViewModel viewModel)
        {
            if (_adminService.Create(viewModel))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult Update(int id, AdminViewModel viewModel)
        {
            if (_adminService.Update(id, viewModel))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (_adminService.Delete(id))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        public bool Login(string username, string password)
        {
            return _adminService.Login(username, password);
        }
    }
}
