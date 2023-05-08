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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Diagnostics;

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
                command.CommandText = "insert into [Reservation] values (@ID, @customer_id, @room_id,@num_adults,@num_children,@occupant,@checkin_date,@checkout_date, @vehicle, @agency, @title, @others, @time)";
                command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = reservation.Id;
                command.Parameters.Add("@customer_id", SqlDbType.Int).Value = reservation.Customer_id;
                command.Parameters.Add("@room_id", SqlDbType.NVarChar).Value = reservation.RoomNumber_id;
                command.Parameters.Add("@num_adults", SqlDbType.Int).Value = reservation.Num_adults;
                command.Parameters.Add("@num_children", SqlDbType.Int).Value = reservation.Num_children;
                command.Parameters.Add("@occupant", SqlDbType.NVarChar).Value = reservation.Occupant;
                command.Parameters.Add("checkin_date", SqlDbType.DateTime).Value = reservation.Checkin_date;
                command.Parameters.Add("checkout_date", SqlDbType.DateTime).Value = reservation.Checkout_date;
                command.Parameters.Add("@vehicle", SqlDbType.NVarChar).Value = reservation.Vehicle;
                command.Parameters.Add("@agency", SqlDbType.NVarChar).Value = reservation.Agency;
                command.Parameters.Add("@title", SqlDbType.NVarChar).Value = reservation.Title;
                command.Parameters.Add("@others", SqlDbType.NVarChar).Value = reservation.Others;
                command.Parameters.Add("@time", SqlDbType.NVarChar).Value = reservation.Time;

                command.ExecuteNonQuery();

            }

        }

        public void Edit(ReservationModel reservation)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;

                command.CommandText = "UPDATE [Reservation] SET customer_id = @customer_id, roomnumber_id = @roomnumber_id, num_adults = @num_adults, num_children = @num_children, occupant = @occupant, checkin_date = @checkin_date, checkout_date = @checkout_date, vehicle = @vehicle, agency = @agency, title = @title, others = @others, time = @time WHERE ID = @ID";

                command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = reservation.Id;
                command.Parameters.Add("@customer_id", SqlDbType.Int).Value = reservation.Customer_id;
                command.Parameters.Add("@roomnumber_id", SqlDbType.NVarChar).Value = reservation.RoomNumber_id;
                command.Parameters.Add("@num_adults", SqlDbType.Int).Value = reservation.Num_adults;
                command.Parameters.Add("@num_children", SqlDbType.Int).Value = reservation.Num_children;
                command.Parameters.Add("@occupant", SqlDbType.NVarChar).Value = reservation.Occupant;
                command.Parameters.Add("checkin_date", SqlDbType.DateTime).Value = reservation.Checkin_date;
                command.Parameters.Add("checkout_date", SqlDbType.DateTime).Value = reservation.Checkout_date;
                command.Parameters.Add("@vehicle", SqlDbType.NVarChar).Value = reservation.Vehicle;
                command.Parameters.Add("@agency", SqlDbType.NVarChar).Value = reservation.Agency;
                command.Parameters.Add("@title", SqlDbType.NVarChar).Value = reservation.Title;
                command.Parameters.Add("@others", SqlDbType.NVarChar).Value = reservation.Others;
                command.Parameters.Add("@time", SqlDbType.NVarChar).Value = reservation.Time;


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
                            RoomNumber_id = reader[1].GetHashCode(),
                            Customer_id = reader[2].GetHashCode(),
                            Num_adults = reader[3].GetHashCode(),
                            Num_children = reader[4].GetHashCode(),
                            Occupant = reader[5].ToString(),
                            Checkin_date = reader.GetDateTime(6).Date,
                            Checkout_date = reader.GetDateTime(7).Date,
                            Vehicle = reader[8].ToString(),
                            Agency = reader[9].ToString(),
                            Title = reader[10].ToString(),
                            Others = reader[11].ToString(),
                            Time = reader[12].ToString(),
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
                        reservation.RoomNumber_id = reader[1].GetHashCode();
                        reservation.Customer_id = reader[2].GetHashCode();
                        reservation.Num_adults = reader[3].GetHashCode();
                        reservation.Num_children = reader[4].GetHashCode();
                        reservation.Occupant = reader[5].ToString();
                        reservation.Checkin_date = reader.GetDateTime(6).Date;
                        reservation.Checkout_date = reader.GetDateTime(7).Date;
                        reservation.Vehicle = reader[8].ToString();
                        reservation.Agency = reader[9].ToString();
                        reservation.Title = reader[10].ToString();
                        reservation.Others = reader[11].ToString();
                        reservation.Time = reader[12].ToString();
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
                command.CommandText = "DELETE FROM [Reservation] WHERE reservation_Id = @reservationId";
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
                            RoomNumber_id = reader[1].GetHashCode(),
                            Customer_id = reader[2].GetHashCode(),
                            Num_adults = reader[3].GetHashCode(),
                            Num_children = reader[4].GetHashCode(),
                            Occupant = reader[5].ToString(),
                            Checkin_date = reader.GetDateTime(6).Date,
                            Checkout_date = reader.GetDateTime(7).Date,
                            Vehicle = reader[8].ToString(),
                            Agency = reader[9].ToString(),
                            Title = reader[10].ToString(),
                            Others = reader[11].ToString(),
                            Time = reader[12].ToString(),
                        };
                        reservations.Add(reservation);
                    }
                }
            }
            return reservations;
        }

        public ObservableCollection<ReservationDataModel> GetAllReservations(int id)
        {
            var reservationsDatas = new ObservableCollection<ReservationDataModel>();
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT Reservation.*, RoomNumber.room_number, Rate.price, Spend.quantity * Spend.price AS packagesTotal, DATEDIFF(day, Reservation.checkin_date, Reservation.checkout_date) AS num_days, Period.* " +
                    "FROM Reservation " +
                    "JOIN RoomNumber ON Reservation.roomnumber_id = RoomNumber.id " +
                    "JOIN Rate ON RoomNumber.room_id = Rate.room_id " +
                    "JOIN Spend ON Reservation.id = Spend.reservation_id " +
                    "JOIN Period ON Reservation.checkin_date >= Period.start_date AND Reservation.checkout_date <= Period.end_date AND Period.season_id = Rate.season_id " +
                    "WHERE customer_id = @id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var reservationData = new ReservationDataModel()
                        {
                            Id = (Guid)reader[0],
                            RoomNumber_id = Convert.ToInt32(reader[1]),
                            Customer_id = Convert.ToInt32(reader[2]),
                            Num_adults = Convert.ToInt32(reader[3]),
                            Num_children = Convert.ToInt32(reader[4]),
                            Occupant = reader[5].ToString(),
                            Checkin_date = reader.GetDateTime(6).Date,
                            Checkout_date = reader.GetDateTime(7).Date,
                            Vehicle = reader[8].ToString(),
                            Agency = reader[9].ToString(),
                            Title = reader[10].ToString(),
                            Others = reader[11].ToString(),
                            Time = reader[12].ToString(),
                            Room_number = reader[14].ToString(),
                            Price = reader.GetDecimal(15),
                            PackagesTotal = reader.GetDecimal(16),
                            TotalDays = Convert.ToInt32(reader[17])
                        };

                        reservationsDatas.Add(reservationData);
                    }
                }
            }
            return reservationsDatas;
        }
    }
}
