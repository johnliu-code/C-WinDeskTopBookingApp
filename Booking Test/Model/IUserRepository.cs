using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Test.Model
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        void Add(UserModel userModel);
        void Edit(UserModel userModel);
        void Remove(Guid id);
        UserModel GetById(Guid id);
        UserModel GetByUsername(string username);
        IEnumerable<UserModel> GetAll(ObservableCollection<UserModel> users);
    }
}
