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
        void Add(CustomerModel CustomerModel);
        void Edit(CustomerModel CustomerModel, int Customerid);
        void Remove(int Customerid);
        CustomerModel GetByCustomerId(int Customerid);
        //CustomerModel GetByCustomerUsername(string firstname, string lastname);
        ObservableCollection<CustomerModel> GetByCustomerUsername(string firstname);
        ObservableCollection<CustomerModel> GetAll();
        ObservableCollection<CustomerModel> Clear();
    }
   
}
