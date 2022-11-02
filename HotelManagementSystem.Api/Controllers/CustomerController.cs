
using HotelManagementSystem.Business.Abstracts;
using HotelManagementSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public CustomerViewModel Get(int id)
        {
            return _customerService.Get(id);
        }
        [HttpGet]
        public List<CustomerViewModel> GetAll()
        {
            return _customerService.GetAll();
        }
    }
}
