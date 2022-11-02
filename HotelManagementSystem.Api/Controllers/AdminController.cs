using HotelManagementSystem.Business.Abstracts;
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
    }
}
