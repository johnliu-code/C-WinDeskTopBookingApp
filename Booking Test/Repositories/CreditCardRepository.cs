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
    public class CreditCardRepository : RepositoryBase, ICreditCardRepository
    {
        public void Add(CreditCardModel creditCardModel)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Insert into [CreditCard] values (@Holder_name, @Card_number, @Expire_date, @CVV, @Card_type, @CustomerId)";
                command.Parameters.Add("@CustomerId", SqlDbType.Int).Value = creditCardModel.Customer_Id;
                command.Parameters.Add("@Holder_name", SqlDbType.NVarChar, 50).Value = creditCardModel.Holder_name;
                command.Parameters.Add("@Card_number", SqlDbType.NVarChar, 50).Value = creditCardModel.Card_number;
                command.Parameters.Add("@Expire_date", SqlDbType.DateTime).Value = creditCardModel.Expire_date;
                command.Parameters.Add("@CVV", SqlDbType.Int).Value = creditCardModel.CVV;
                command.Parameters.Add("@Card_type", SqlDbType.NVarChar, 50).Value = creditCardModel.Card_type;

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Edit(CreditCardModel creditCardModel)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Update [CreditCard] set Customer_Id = @CustomerId, Holder_name = @Holder_name, Card_number = @Card_number, Expire_date = @Expire_date, CVV = @CVV, Card_type = @Card_type where Id = @id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = creditCardModel.Id;
                command.Parameters.Add("@CustomerId", SqlDbType.Int).Value = creditCardModel.Customer_Id;
                command.Parameters.Add("@Holder_name", SqlDbType.NVarChar, 50).Value = creditCardModel.Holder_name;
                command.Parameters.Add("@Card_number", SqlDbType.NVarChar, 50).Value = creditCardModel.Card_number;
                command.Parameters.Add("@Expire_date", SqlDbType.DateTime).Value = creditCardModel.Expire_date;
                command.Parameters.Add("@CVV", SqlDbType.Int).Value = creditCardModel.CVV;
                command.Parameters.Add("@Card_type", SqlDbType.NVarChar, 50).Value = creditCardModel.Card_type;

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public CreditCardModel GetByCreditCardId(int id)
        {
            CreditCardModel creditCard = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from [CreditCard] where Id=@id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        creditCard = new CreditCardModel()
                        {
                            Id = reader[0].GetHashCode(),                           
                            Holder_name = reader[1].ToString(),
                            Card_number = reader[2].ToString(),
                            Expire_date = reader.GetDateTime(3),   
                            CVV = reader[4].GetHashCode(),
                            Card_type = reader[5].ToString(),
                            Customer_Id = reader[6].GetHashCode(),
                        };
                    }
                }
            }
            return creditCard;
        }

        public ObservableCollection<CreditCardModel> GetByCustomerId(int id)
        {
            CreditCardModel creditCard = null;
            var creditCards = new ObservableCollection<CreditCardModel>();
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from [CreditCard] where Customer_Id=@id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        creditCard = new CreditCardModel()
                        {
                            Id = reader[0].GetHashCode(),
                            Holder_name = reader[1].ToString(),
                            Card_number = reader[2].ToString(),
                            Expire_date = reader.GetDateTime(3),
                            CVV = reader[4].GetHashCode(),
                            Card_type = reader[5].ToString(),
                            Customer_Id = reader[6].GetHashCode(),
                        };
                        creditCards.Add(creditCard);
                    }
                }
            }
            return creditCards;
        }


        public ObservableCollection<CreditCardModel> GetAll(ObservableCollection<CreditCardModel> creditCards)
        {
            CreditCardModel creditCard = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from [CreditCard] ORDER BY Id";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        creditCard = new CreditCardModel()
                        {
                            Id = reader[0].GetHashCode(),
                            Customer_Id = reader[1].GetHashCode(),
                            Holder_name = reader[2].ToString(),
                            Expire_date = reader.GetDateTime(3),
                            Card_number = reader[4].ToString(),                            
                            CVV = reader[5].GetHashCode(),
                            Card_type = reader[6].ToString(),
                        };
                        creditCards.Add(creditCard);
                    }
                }
            }
            return creditCards;
        }

        public void Remove(int id)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Delete [CreditCard] where Id=@id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

    }
}
