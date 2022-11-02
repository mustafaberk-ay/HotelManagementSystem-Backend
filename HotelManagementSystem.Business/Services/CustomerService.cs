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

        public bool Create(CustomerViewModel customer)
        {
            try
            {
                var entity = new Customer()
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber,
                    Country = customer.Country,
                    HasReservation = customer.HasReservation
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

        public bool Delete(int id)
        {
            try
            {
                var entity = _context.Customers.FirstOrDefault(x => x.Id == id);
                _context.Customers.Remove(entity);
            }
            catch (Exception)
            {
                throw;
            }
            return true;
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
            foreach (var customer in customersFromDb)
            {
                customerList.Add(new CustomerViewModel()
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber,
                    Country = customer.Country,
                    HasReservation = customer.HasReservation
                });
            }
            return customerList;
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

        public bool Update(int id, CustomerViewModel customer)
        {
            try
            {
                var entity = _context.Customers.FirstOrDefault(x => x.Id == id);
                if (entity != null)
                {
                    entity.FirstName = customer.FirstName;
                    entity.LastName = customer.LastName;
                    entity.PhoneNumber = customer.PhoneNumber;
                    entity.Country = customer.Country;
                    entity.HasReservation = customer.HasReservation;
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
