using Booking_Test.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Collections.ObjectModel;
using System.Windows;

namespace Booking_Test.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel user)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Insert into [User] (username,password, roll, permission, email, phone) values (@username, @password, @roll, @permission, @email, @phone)";
                command.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = user.Username;
                command.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = user.Password;
                command.Parameters.Add("@roll", SqlDbType.NVarChar, 50).Value = user.Roll;
                command.Parameters.Add("@permission", SqlDbType.NVarChar, 50).Value = user.Permission;
                command.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = user.Email;
                command.Parameters.Add("@phone", SqlDbType.NVarChar, 50).Value = user.Phone;

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection=GetConnection())
            using (var command=new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from [User] where username=@username and [password]=@password";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }

        public void Edit(UserModel updateuser)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Update [User]  set username = @username, password = @password, roll = @roll, permission = @permission, email = @email, phone = @phone where Id = @id";
                command.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = updateuser.Username;
                command.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = updateuser.Password;
                command.Parameters.Add("@roll", SqlDbType.NVarChar, 50).Value = updateuser.Roll;
                command.Parameters.Add("@permission", SqlDbType.NVarChar, 50).Value = updateuser.Permission;
                command.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = updateuser.Email;
                command.Parameters.Add("@phone", SqlDbType.NVarChar, 50).Value = updateuser.Phone;
                command.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = updateuser.Id;

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public IEnumerable<UserModel> GetAll(ObservableCollection<UserModel> users)
        {
            UserModel user = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from [User] ORDER BY Id";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = (Guid)reader[0],
                            Username = reader[1].ToString(),
                            Password = reader[2].ToString(),
                            Roll = reader[3].ToString(),
                            Permission = reader[4].ToString(),
                            Email = reader[5].ToString(),
                            Phone = reader[6].ToString()
                        };
                        users.Add(user);
                    }
                }
                connection.Close();
            }
            return users;
        }


public UserModel GetById(Guid id)
        {
            UserModel user = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from [User] where Id=@id";
                command.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = (Guid)reader[0],
                            Username = reader[1].ToString(),
                            Password = String.Empty,
                            Roll = reader[3].ToString(),
                            Permission = reader[4].ToString(),
                            Email = reader[5].ToString(),
                            Phone = reader[6].ToString()
                        };
                    }
                }
            }
            return user;
        }

        public UserModel GetByUsername(string username)
        {
            UserModel user = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from [User] where username=@username";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = (Guid)reader[0],
                            Username = reader[1].ToString(),
                            Password = reader[2].ToString(),
                            Roll = reader[3].ToString(),
                            Permission = reader[4].ToString(),
                            Email = reader[5].ToString(),
                            Phone = reader[6].ToString()
                        };
                    }
                }
            }
            return user;
        }

        public void Remove(Guid id)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Delete [User] where Id=@id";
                command.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;

                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
