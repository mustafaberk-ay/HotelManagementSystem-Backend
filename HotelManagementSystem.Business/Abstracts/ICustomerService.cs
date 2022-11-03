using HotelManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Business.Abstracts
{
    public interface ICustomerService
    {
        CustomerViewModel Get(int id);
        List<CustomerViewModel> GetAll();
        bool Create (CustomerViewModel viewModel);
        bool Update (int id, CustomerViewModel viewModel);
        bool Delete (int id);
        bool HasReservation(int customerId);
        bool MakeReservation(int customerId, int roomId);
    }
}
