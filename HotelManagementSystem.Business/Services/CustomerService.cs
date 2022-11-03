using HotelManagementSystem.Business.Abstracts;
using HotelManagementSystem.DataModels.DataModels;
using HotelManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HotelManagementDbContext _context;
        public CustomerService(HotelManagementDbContext context)
        {
            _context = context;
        }
        public CustomerViewModel Get(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            var customerViewModel = new CustomerViewModel()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                Country = customer.Country,
                HasReservation = customer.HasReservation
            };
            return customerViewModel;
        }

        public List<CustomerViewModel> GetAll()
        {
            var customersFromDb = _context.Customers.ToList();
            var customerList = new List<CustomerViewModel>();
            foreach (var item in customersFromDb)
            {
                customerList.Add(new CustomerViewModel()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    PhoneNumber = item.PhoneNumber,
                    Country = item.Country,
                    HasReservation = item.HasReservation
                });
            }
            return customerList;
        }

        public bool Create(CustomerViewModel viewModel)
        {
            try
            {
                var entity = new Customer()
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    PhoneNumber = viewModel.PhoneNumber,
                    Country = viewModel.Country,
                    HasReservation = viewModel.HasReservation
                };
                _context.Customers.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }
        public bool Update(int id, CustomerViewModel viewModel)
        {
            try
            {
                var entity = _context.Customers.FirstOrDefault(x => x.Id == id);
                if (entity != null)
                {
                    entity.FirstName = viewModel.FirstName;
                    entity.LastName = viewModel.LastName;
                    entity.PhoneNumber = viewModel.PhoneNumber;
                    entity.Country = viewModel.Country;
                    entity.HasReservation = viewModel.HasReservation;
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = _context.Customers.FirstOrDefault(x => x.Id == id);
                _context.Customers.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }

        
        public bool HasReservation(int customerId)
        {
            var customerReservation = _context.Rooms.FirstOrDefault(x => x.ReservedCustomerId == customerId);
            if(customerReservation == null)
            {
                return false;
            }
            return true;
        }

        public bool MakeReservation(int customerId, int roomId)
        {
            try
            {
                var room = _context.Rooms.SingleOrDefault(x => x.Id == roomId);
                if (room.IsFree)
                {
                    var customerWhoReservedTheRoom = _context.Customers.SingleOrDefault(x => x.Id == customerId);
                    room.ReservedCustomerId = customerId;
                    room.ReservedCustomer = customerWhoReservedTheRoom;
                    room.IsFree = false;
                    customerWhoReservedTheRoom.HasReservation = true;
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("You cannot reserve a occupied room!");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }
    }
}
