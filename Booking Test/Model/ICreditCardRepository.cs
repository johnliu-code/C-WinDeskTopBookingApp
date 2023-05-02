using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Test.Model
{
    public interface ICreditCardRepository
    {
        void Add(CreditCardModel creditCardModel);
        void Edit(CreditCardModel creditCardModel);
        void Remove(int id);
        CreditCardModel GetByCreditCardId(int id);
        ObservableCollection<CreditCardModel> GetByCustomerId(int id);
        ObservableCollection<CreditCardModel> GetAll(ObservableCollection<CreditCardModel> creditCards);
    }
}
