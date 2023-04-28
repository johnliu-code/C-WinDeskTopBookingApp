using Booking_Test.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Test.Repositories
{
    public class CustomerRepository : RepositoryBase, ICustomerRepository
    {
        public void Add(CustomerModel customer)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Insert into [User] (first_name,last_name, title, phone, email, street, city, state, country, postal_code, creditcrad_id) values (@first_name, @last_name, @title, @phone, @email, @street, @city, @state, @country, @postal_code, @creditcrad_id)";
                command.Parameters.Add("@first_name", SqlDbType.NVarChar, 50).Value = customer.First_name;
                command.Parameters.Add("@last_name", SqlDbType.NVarChar, 50).Value = customer.Last_name;
                command.Parameters.Add("@title", SqlDbType.NVarChar, 50).Value = customer.Title;
                command.Parameters.Add("@phone", SqlDbType.NVarChar, 50).Value = customer.Phone;
                command.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = customer.Email;
                command.Parameters.Add("@street", SqlDbType.NVarChar, 50).Value = customer.Street;
                command.Parameters.Add("@city", SqlDbType.NVarChar, 50).Value = customer.City;
                command.Parameters.Add("@state", SqlDbType.NVarChar, 50).Value = customer.State;
                command.Parameters.Add("@country", SqlDbType.NVarChar, 50).Value = customer.Country;
                command.Parameters.Add("@postal_code", SqlDbType.NVarChar, 50).Value = customer.Postal_code;
                command.Parameters.Add("@creditcard_id", SqlDbType.NVarChar, 50).Value = customer.CreditCardId;

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public ObservableCollection<CustomerModel> Clear()
        {
            throw new NotImplementedException();
        }

        public void Edit(CustomerModel customer)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Update [User] set first_name = @first_name,last_name = @last_name, title = @title, phone = @phone, email = @email, street = @street, city = @city, state = @state, country = @country, postal_code = @postal_code where id = @id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = customer.Id;
                command.Parameters.Add("@first_name", SqlDbType.NVarChar, 50).Value = customer.First_name;
                command.Parameters.Add("@last_name", SqlDbType.NVarChar, 50).Value = customer.Last_name;
                command.Parameters.Add("@title", SqlDbType.NVarChar, 50).Value = customer.Title;
                command.Parameters.Add("@phone", SqlDbType.NVarChar, 50).Value = customer.Phone;
                command.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = customer.Email;
                command.Parameters.Add("@street", SqlDbType.NVarChar, 50).Value = customer.Street;
                command.Parameters.Add("@city", SqlDbType.NVarChar, 50).Value = customer.City;
                command.Parameters.Add("@state", SqlDbType.NVarChar, 50).Value = customer.State;
                command.Parameters.Add("@country", SqlDbType.NVarChar, 50).Value = customer.Country;
                command.Parameters.Add("@postal_code", SqlDbType.NVarChar, 50).Value = customer.Postal_code;
                command.Parameters.Add("@creditcard_id", SqlDbType.NVarChar, 50).Value = customer.CreditCardId;

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public ObservableCollection<CustomerModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<CustomerModel> GetByCustomerId(int id)
        {
            throw new NotImplementedException();
        }

        public CustomerModel GetByCustomerName(string name)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
