using Booking_Test.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Test.Repositories
{
    public class CreditCardRepository : RepositoryBase, ICreditCardRepository
    {
        public void Add(CreditCardModel creditCardModel)
        {
            throw new NotImplementedException();
        }

        public void Edit(CreditCardModel creditCardModel, int id)
        {
            throw new NotImplementedException();
        }

        public CreditCardModel GetByCreditCardId(int id)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<CreditCardModel> GetByCustomerId(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
