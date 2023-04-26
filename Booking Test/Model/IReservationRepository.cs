using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Test.Model
{
    public interface IReservationRepository
    {        
        void Add(ReservationModel reservationModel);
        void Edit(ReservationModel reservationModel, Guid reservationid);
        void Remove(Guid reservationid);
        ReservationModel GetByReservationId(Guid reservationid);
        //ReservationModel GetByReservationUsername(string firstname, string lastname);
        ObservableCollection<ReservationModel> GetByReservationUsername(string firstname);
        ObservableCollection<ReservationModel> GetAll();
        ObservableCollection<ReservationModel> Clear();
    }
}
