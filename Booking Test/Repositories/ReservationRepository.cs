using Booking_Test.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Test.Repositories
{
    public class ReservationRepository : RepositoryBase, IReservationRepository
    {
        public void Add(ReservationModel reservationModel)
        {
            var reservation = reservationModel;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into [Reservation] values (@ID, @customer_id, @room_id,@num_adults,@num_children,@occupant,@checkin_date,@checkout_date, @vehicle, @agency)";
                command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = reservation.Id;
                command.Parameters.Add("@customer_id", SqlDbType.Int).Value = reservation.Customer_id;
                command.Parameters.Add("@room_id", SqlDbType.NVarChar).Value = reservation.Room_id;
                command.Parameters.Add("@num_adults", SqlDbType.Int).Value = reservation.Num_adults;
                command.Parameters.Add("@num_children", SqlDbType.Int).Value = reservation.Num_children;
                command.Parameters.Add("@occupant", SqlDbType.NVarChar).Value = reservation.Occupant;
                command.Parameters.Add("checkin_date", SqlDbType.DateTime).Value = reservation.Checkin_date;
                command.Parameters.Add("checkout_date", SqlDbType.DateTime).Value = reservation.Checkout_date;
                command.Parameters.Add("@vehicle", SqlDbType.Int).Value = reservation.Vehicle;
                command.Parameters.Add("@agency", SqlDbType.Int).Value = reservation.Agency;

                command.ExecuteNonQuery();

            }

        }

        public void Edit(ReservationModel reservationModel)
        {
            var reservation = reservationModel;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;

                command.CommandText = "UPDATE [Reservation] SET customer_id = @customer_id, room_id = @room_id, num_adults = @num_adults, num_children = @num_children, occupant = @occupant, checkin_date = @checkin_date, checkout_date = @checkout_date, vehicle = @vehicle, agency = @agency WHERE ID = @ID";

                command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = reservation.Id;
                command.Parameters.Add("@customer_id", SqlDbType.Int).Value = reservation.Customer_id;
                command.Parameters.Add("@room_id", SqlDbType.NVarChar).Value = reservation.Room_id;
                command.Parameters.Add("@num_adults", SqlDbType.Int).Value = reservation.Num_adults;
                command.Parameters.Add("@num_children", SqlDbType.Int).Value = reservation.Num_children;
                command.Parameters.Add("@occupant", SqlDbType.NVarChar).Value = reservation.Occupant;
                command.Parameters.Add("checkin_date", SqlDbType.DateTime).Value = reservation.Checkin_date;
                command.Parameters.Add("checkout_date", SqlDbType.DateTime).Value = reservation.Checkout_date;
                command.Parameters.Add("@vehicle", SqlDbType.Int).Value = reservation.Vehicle;
                command.Parameters.Add("@agency", SqlDbType.Int).Value = reservation.Agency;

                command.ExecuteNonQuery();
            }
        }


        public ObservableCollection<ReservationModel> Clear()
        {
            var reservations = new ObservableCollection<ReservationModel>();
            reservations.Clear();
            return reservations;
        }

        public ObservableCollection<ReservationModel> GetAll()
        {
            var reservations = new ObservableCollection<ReservationModel>();
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [Reservation]";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var reservation = new ReservationModel()
                        {
                            Id = (Guid)reader[0],
                            Room_id = reader[1].GetHashCode(),
                            Customer_id = reader[2].GetHashCode(),
                            Num_adults = reader[3].GetHashCode(),
                            Num_children = reader[4].GetHashCode(),
                            Occupant = reader[5].ToString(),
                            Checkin_date = reader.GetDateTime(6),
                            Checkout_date = reader.GetDateTime(7),
                            Vehicle = reader[8].ToString(),
                            Agency = reader[9].ToString()
                        };
                        reservations.Add(reservation);
                    }
                }
            }
            return reservations;
        }

        public ReservationModel GetByCheckinDate(DateTime checkindate)
        {
            var reservation = new ReservationModel();
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from [Reservation] where Checkin_date = @Checkin_date";
                command.Parameters.Add("@Checkin_date", SqlDbType.DateTime).Value = checkindate;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reservation.Id = (Guid)reader[0];
                        reservation.Room_id = reader[1].GetHashCode();
                        reservation.Customer_id = reader[2].GetHashCode();
                        reservation.Num_adults = reader[3].GetHashCode();
                        reservation.Num_children = reader[4].GetHashCode();
                        reservation.Occupant = reader[5].ToString();
                        reservation.Checkin_date = reader.GetDateTime(6);
                        reservation.Checkout_date = reader.GetDateTime(7);
                        reservation.Vehicle = reader[8].ToString();
                        reservation.Agency = reader[9].ToString();
                    }
                }
            }
            return reservation;
        }

        public void Remove(Guid reservationid)
        {

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM [Reservation] WHERE reservationId = @reservationId";
                command.Parameters.AddWithValue("@reservationId", reservationid);
                command.ExecuteNonQuery();

            }

        }

        public ObservableCollection<ReservationModel> GetByCustomerId(int id)
        {
            var reservations = new ObservableCollection<ReservationModel>();
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from [Reservation] where customer_id = @id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var reservation = new ReservationModel()
                        {
                            Id = (Guid)reader[0],
                            Room_id = reader[1].GetHashCode(),
                            Customer_id = reader[2].GetHashCode(),
                            Num_adults = reader[3].GetHashCode(),
                            Num_children = reader[4].GetHashCode(),
                            Occupant = reader[5].ToString(),
                            Checkin_date = reader.GetDateTime(6),
                            Checkout_date = reader.GetDateTime(7),
                            Vehicle = reader[8].ToString(),
                            Agency = reader[9].ToString()
                        };
                        reservations.Add(reservation);
                    }
                }
            }
            return reservations;
        }
    }
}
