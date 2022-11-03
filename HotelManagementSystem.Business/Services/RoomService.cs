using HotelManagementSystem.Business.Abstracts;
using HotelManagementSystem.DataModels.DataModels;
using HotelManagementSystem.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Business.Services
{
    public class RoomService : IRoomService
    {
        private readonly HotelManagementDbContext _context;
        public RoomService(HotelManagementDbContext context)
        {
            _context = context;
        }
        public RoomViewModel Get(int id)
        {
            var room = _context.Rooms.SingleOrDefault(x => x.Id == id);
            var customer = _context.Customers.SingleOrDefault(x => x.Id == room.ReservedCustomerId);
            var roomViewModel = new RoomViewModel()
            {
                Id = room.Id,
                RoomNumber = room.RoomNumber,
                RoomType = room.RoomType,
                IsFree = room.IsFree,
                PhoneNumber = room.PhoneNumber,
                ReservedCustomerFullname = customer != null ? customer.FirstName + " " + customer.LastName : null
            };
            return roomViewModel;
        }
        public List<RoomViewModel> GetAll()
        {
            var roomsFromDb = _context.Rooms.ToList();
            var roomList = new List<RoomViewModel>();
            foreach (var item in roomsFromDb)
            {
                var customer = _context.Customers.SingleOrDefault(x => x.Id == item.ReservedCustomerId);
                roomList.Add(new RoomViewModel()
                {
                    Id = item.Id,
                    RoomNumber = item.RoomNumber,
                    RoomType = item.RoomType,
                    IsFree = item.IsFree,
                    PhoneNumber = item.PhoneNumber,
                    ReservedCustomerFullname = customer != null ? customer.FirstName + " " + customer.LastName : null
                }) ;
            }
            return roomList;
        }
        public bool Create(RoomViewModel viewModel)
        {
            try
            {
                var entity = new Room()
                {
                    RoomNumber = viewModel.RoomNumber,
                    RoomType = viewModel.RoomType, 
                    IsFree = viewModel.IsFree,
                    PhoneNumber = viewModel.PhoneNumber
                };
                _context.Rooms.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }
        public bool Update(int id, RoomViewModel viewModel)
        {
            try
            {
                var entity = _context.Rooms.FirstOrDefault(x => x.Id == id);
                if (entity != null)
                {
                    entity.RoomNumber = viewModel.RoomNumber;
                    entity.RoomType = viewModel.RoomType;
                    entity.IsFree = viewModel.IsFree;
                    entity.PhoneNumber = viewModel.PhoneNumber;
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
                var entity = _context.Rooms.FirstOrDefault(x => x.Id == id);
                _context.Rooms.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }
        public bool CheckIn(int roomId)
        {
            try
            {
                var roomToCheckIn = _context.Rooms.SingleOrDefault(x => x.Id == roomId);
                roomToCheckIn.IsFree = false;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }

        public bool CheckOut(int roomId)
        {
            try
            {
                var roomToCheckOut = _context.Rooms.SingleOrDefault(x => x.Id == roomId);
                var customerToCheckOut = _context.Customers.SingleOrDefault(x => x.Id == roomToCheckOut.ReservedCustomerId);
                customerToCheckOut.HasReservation = false;
                roomToCheckOut.ReservedCustomerId = null;
                roomToCheckOut.IsFree = true;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }
    }
}
