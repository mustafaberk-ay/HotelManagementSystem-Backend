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
    public class AdminService : IAdminService
    {
        private readonly HotelManagementDbContext _context;
        public AdminService(HotelManagementDbContext context)
        {
            _context = context;
        }
        public AdminViewModel Get(int id)
        {
            var admin = _context.Admins.SingleOrDefault(x => x.Id == id);
            var adminViewModel = new AdminViewModel()
            {
                Id = admin.Id,
                Password = admin.Password,
                Username = admin.Username
            };
            return adminViewModel;
        }

        public List<AdminViewModel> GetAll()
        {
            var adminListFromDb = _context.Admins.ToList();
            var adminList = new List<AdminViewModel>();
            foreach (var admin in adminListFromDb)
            {
                adminList.Add(new AdminViewModel()
                {
                    Id = admin.Id,
                    Username = admin.Username,
                    Password = admin.Password
                });
            }
            return adminList;
        }
        public bool Create(AdminViewModel viewModel)
        {
            try
            {
                var entity = new Admin()
                {
                    Username = viewModel.Username,
                    Password = viewModel.Password
                };
                _context.Admins.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }
        public bool Update(int id, AdminViewModel viewModel)
        {
            try
            {
                var entity = _context.Admins.FirstOrDefault(x => x.Id == id);
                if (entity != null)
                {
                    entity.Username = viewModel.Username;
                    entity.Password = viewModel.Password;
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
                var entity = _context.Admins.FirstOrDefault(x => x.Id == id);
                _context.Admins.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }

        public bool Login(string username, string password)
        {
            var adminListFromDb = _context.Admins.ToList();
            foreach(var admin in adminListFromDb)
            {
                if(admin.Username == username && admin.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
