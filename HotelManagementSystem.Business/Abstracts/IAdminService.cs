using HotelManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Business.Abstracts
{
    public interface IAdminService
    {
        AdminViewModel Get(int id);
        List<AdminViewModel> GetAll();
        bool Create(AdminViewModel viewModel);
        bool Update(int id, AdminViewModel viewModel);
        bool Delete(int id);
        bool Login(string username, string password);
    }
}
