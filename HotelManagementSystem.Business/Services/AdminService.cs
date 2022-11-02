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
            var admin = _context.Admins.FirstOrDefault<Admin>();
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
            foreach (var admin in adminList)
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
