
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
        [HttpPost]
        public IActionResult Create(CustomerViewModel viewModel)
        {
            if (_customerService.Create(viewModel))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult Update(int id, CustomerViewModel viewModel)
        {
            if(_customerService.Update(id, viewModel))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (_customerService.Delete(id))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        public bool HasReservation(int customerId)
        {
            return _customerService.HasReservation(customerId);
        }
        [HttpPut]
        public IActionResult MakeReservation(int customerId, int roomId)
        {
            if (_customerService.MakeReservation(customerId, roomId))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
