using Booking_Test.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net;
using System.Data;
using System.Collections.ObjectModel;

namespace Booking_Test.Repositories
{
    public class ReservationRepository: RepositoryBase, IReservationRepository
    {
        public void Add(ReservationModel reservationModel)
        {
            var reservation = reservationModel;            
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open(); 
                command.Connection = connection;
                //command.CommandText = "insert into [Reservation] values (@reservationID, @fistname,@lastname,@number,@phone,@email,@address,@roomnumber)";
                command.CommandText = "insert into [Reservation] values (@reservationID, @customerID,@number,@roomnumber)";
                command.Parameters.Add("@reservationID", SqlDbType.UniqueIdentifier).Value = reservation.ReservationId;
                //command.Parameters.Add("@firstname", SqlDbType.NVarChar).Value = reservation.Firstname;
                //command.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = reservation.Lastname;
                command.Parameters.Add("@customerID", SqlDbType.Int).Value = reservation.CustomerId;
                command.Parameters.Add("@number", SqlDbType.Int).Value = reservation.Number;
                //command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = reservation.Phone;
                //command.Parameters.Add("@email", SqlDbType.NVarChar).Value = reservation.Email;                
                //command.Parameters.Add("@address", SqlDbType.NVarChar).Value = reservation.Address;
                command.Parameters.Add("@roomnumber", SqlDbType.Int).Value = reservation.RoomNumber;
                command.ExecuteNonQuery();


            }
           
        }        
    
        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from [Reservation] where firstname=@firstname and lastname=@lastname";
                command.Parameters.Add("@firstname", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }

        public void Edit(ReservationModel reservationModel, Guid reservationid)
        {
            var reservation = reservationModel;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
               
                //command.CommandText = "UPDATE [Reservation] SET Firstname = @firstname, Lastname = @lastname, Number = @number, Phone = @phone, Email = @email, Address = @address, RoomNumber = @roomnumber WHERE ReservationID = @reservationID";
                command.CommandText = "UPDATE [Reservation] SET CustomerId = @customerID, Number = @number,RoomNumber = @roomnumber WHERE ReservationID = @reservationID";
                command.Parameters.Add("@reservationID", SqlDbType.UniqueIdentifier).Value = reservationid;
                //command.Parameters.Add("@firstname", SqlDbType.NVarChar).Value = reservation.Firstname;
                //command.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = reservation.Lastname;
                command.Parameters.Add("@customerID", SqlDbType.Int).Value = reservation.CustomerId;
                command.Parameters.Add("@number", SqlDbType.Int).Value = reservation.Number;
                //command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = reservation.Phone;
                //command.Parameters.Add("@email", SqlDbType.NVarChar).Value = reservation.Email;
                //command.Parameters.Add("@address", SqlDbType.NVarChar).Value = reservation.Address;
                command.Parameters.Add("@roomnumber", SqlDbType.Int).Value = reservation.RoomNumber;
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
                            ReservationId = (Guid)reader[0],
                            //Firstname = reader[1].ToString(),
                            //Lastname = reader[2].ToString(),
                            CustomerId = reader[1].GetHashCode(),
                            Number = reader[2].GetHashCode(),
                            //Phone = reader[4].ToString(),
                            //Email = reader[5].ToString(),
                            //Address = reader[6].ToString(),
                            RoomNumber = reader[3].GetHashCode()
                        };
                        reservations.Add(reservation);
                    }
                }
            }
            return reservations;
        }

        public ReservationModel GetByReservationId(Guid reservationid)
        {
            var reservation = new ReservationModel();
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from [Reservation] where reservationId = @reservationId";
                command.Parameters.Add(" @reservationId", SqlDbType.UniqueIdentifier).Value =reservationid;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reservation.ReservationId = (Guid)reader[0];
                        //reservation.Firstname = reader[1].ToString();
                        //reservation.Lastname = reader[2].ToString();
                        reservation.Number = reader[3].GetHashCode();
                        //reservation.Phone = reader[4].ToString();
                        //reservation.Email = reader[5].ToString();
                        //reservation.Address = reader[6].ToString();
                        reservation.RoomNumber = reader[7].GetHashCode();
                       
                    }
                }
            }
            return reservation;
        }

        public ObservableCollection<ReservationModel> GetByCustomerId(int customerId)
        {

            var reservations = new ObservableCollection<ReservationModel>();
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from [Reservation] where customer_id = @customerId";
                command.Parameters.Add("@customerId", SqlDbType.NVarChar).Value = customerId;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var reservation = new ReservationModel()
                        {
                            ReservationId = (Guid)reader[0],
                            //Firstname = reader[1].ToString(),
                            //Lastname = reader[2].ToString(),
                            CustomerId= reader[1].GetHashCode(),
                            Number = reader[2].GetHashCode(),
                            //Phone = reader[4].ToString(),
                            //Email = reader[5].ToString(),
                            //Address = reader[6].ToString(),
                            RoomNumber = reader[3].GetHashCode()
                        };
                        reservations.Add(reservation);
                    }
                }
            }
            return reservations;
        }
        //public ObservableCollection<ReservationModel> GetByReservationUsername(string firstname)
        //{
                  
        //    var reservations = new ObservableCollection<ReservationModel>();
        //    using (var connection = GetConnection())
        //    using (var command = new SqlCommand())
        //    {
        //        connection.Open();
        //        command.Connection = connection;
        //        command.CommandText = "Select * from [Reservation] where firstname = @firstname";
        //        command.Parameters.Add("@firstname", SqlDbType.NVarChar).Value = firstname;
        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                var reservation = new ReservationModel()
        //                {
        //                    ReservationId = (Guid)reader[0],
        //                    //Firstname = reader[1].ToString(),
        //                    //Lastname = reader[2].ToString(),
        //                    Number = reader[3].GetHashCode(),
        //                    //Phone = reader[4].ToString(),
        //                    //Email = reader[5].ToString(),
        //                    //Address = reader[6].ToString(),
        //                    RoomNumber = reader[7].GetHashCode()
        //                };
        //                reservations.Add(reservation);
        //            }
        //        }
        //    }
        //    return reservations;
        //}

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
    }
}
