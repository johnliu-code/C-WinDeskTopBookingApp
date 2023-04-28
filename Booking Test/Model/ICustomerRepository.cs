using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Test.Model
{
    public interface ICustomerRepository
    {
        void Add(CustomerModel customerModel);
        void Edit(CustomerModel customerModel);
        void Remove(int id);
        CustomerModel GetByCustomerName(string name);
        ObservableCollection<CustomerModel> GetByCustomerId(int id);
        ObservableCollection<CustomerModel> GetAll();
        ObservableCollection<CustomerModel> Clear();
    }
}
