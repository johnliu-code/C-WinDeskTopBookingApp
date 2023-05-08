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
        void Edit(ReservationModel reservationModel);
        void Remove(Guid reservationid);
        ReservationModel GetByCheckinDate(DateTime checkindate);
        ObservableCollection<ReservationModel> GetByCustomerId(int id);
        ObservableCollection<ReservationModel> GetAll();
        ObservableCollection<ReservationDataModel> GetAllReservations(int id);
        ObservableCollection<ReservationModel> Clear();
    }
}
