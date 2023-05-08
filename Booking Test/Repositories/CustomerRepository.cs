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
    public class CustomerRepository : RepositoryBase, ICustomerRepository
    {
        public void Add(CustomerModel CustomerModel)
        {
            var customer = CustomerModel;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into [Customer] values (@customerID, @firstname, @lastname,@phone,@email,@address)";
                command.Parameters.Add("@customerID", SqlDbType.Int).Value = customer.CustomerId;
                command.Parameters.Add("@firstname", SqlDbType.NVarChar).Value = customer.Firstname;
                command.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = customer.Lastname;
               
                command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = customer.Phone;
                command.Parameters.Add("@email", SqlDbType.NVarChar).Value = customer.Email;
                command.Parameters.Add("@address", SqlDbType.NVarChar).Value = customer.Address;
               
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
                command.CommandText = "Select * from [Customer] where firstname=@firstname and lastname=@lastname";
                command.Parameters.Add("@firstname", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }

        public void Edit(CustomerModel CustomerModel, int customerid)
        {
            var customer = CustomerModel;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;

                command.CommandText = "UPDATE [Customer] SET Firstname = @firstname, Lastname = @lastname,Phone = @phone, Email = @email, Address = @address, RoomNumber = @roomnumber WHERE customerID = @customerID";

                command.Parameters.Add("@customerID", SqlDbType.Int).Value = customerid;
                command.Parameters.Add("@firstname", SqlDbType.NVarChar).Value = customer.Firstname;
                command.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = customer.Lastname;
                //command.Parameters.Add("@number", SqlDbType.Int).Value = customer.Number;
                command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = customer.Phone;
                command.Parameters.Add("@email", SqlDbType.NVarChar).Value = customer.Email;
                command.Parameters.Add("@address", SqlDbType.NVarChar).Value = customer.Address;
                
                command.ExecuteNonQuery();


            }

        }


        public ObservableCollection<CustomerModel> Clear()
        {
            var customers = new ObservableCollection<CustomerModel>();
            customers.Clear();
            return customers;
        }

        public ObservableCollection<CustomerModel> GetAll()
        {
            var customers = new ObservableCollection<CustomerModel>();
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [Customer]";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var customer = new CustomerModel()
                        {
                            CustomerId = (int)reader[0],
                            Firstname = reader[1].ToString(),
                            Lastname = reader[2].ToString(),
                            //Number = reader[3].GetHashCode(),
                            //Phone = reader[4].ToString(),
                            //Email = reader[5].ToString(),
                            //Address = reader[6].ToString(),
                            Phone = reader[3].ToString(),
                            Email = reader[4].ToString(),
                            Address = reader[5].ToString(),

                        };
                        customers.Add(customer);
                    }
                }
            }
            return customers;
        }

        public CustomerModel GetByCustomerId(int customerid)
        {
            var customer = new CustomerModel();
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from [Customer] where id = @customerId";
                command.Parameters.Add("@customerId", SqlDbType.Int).Value = customerid;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customer.CustomerId = (int)reader[0];
                        customer.Firstname = reader[1].ToString();
                        customer.Lastname = reader[2].ToString();
                        //customer.Number = reader[3].GetHashCode();
                        //customer.Phone = reader[4].ToString();
                        //customer.Email = reader[5].ToString();
                        //customer.Address = reader[6].ToString();
                        customer.Phone = reader[3].ToString();
                        customer.Email = reader[4].ToString();
                        customer.Address = reader[5].ToString();
                       

                    }
                }
            }
            return customer;
        }

        //public CustomerModel GetByCustomerUsername(string firstname,string lastname)
        public ObservableCollection<CustomerModel> GetByCustomerUsername(string firstname)
        {

            var customers = new ObservableCollection<CustomerModel>();
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from [Customer] where first_name = @firstname";
                command.Parameters.Add("@firstname", SqlDbType.NVarChar).Value = firstname;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var customer = new CustomerModel()
                        {
                            CustomerId = (int)reader[0],
                            Firstname = reader[1].ToString(),
                            Lastname = reader[2].ToString(),
                            //Number = reader[3].GetHashCode(),
                            //Phone = reader[4].ToString(),
                            //Email = reader[5].ToString(),
                            //Address = reader[6].ToString(),
                            Phone = reader[3].ToString(),
                            Email = reader[4].ToString(),
                            Address = reader[5].ToString(),

                        };
                        customers.Add(customer);
                    }
                }
            }
            return customers;
        }

        public void Remove(int customerid)
        {

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM [Customer] WHERE customerId = @customerId";
                command.Parameters.AddWithValue("@customerId", customerid);
                command.ExecuteNonQuery();

            }

        }
    }
}
