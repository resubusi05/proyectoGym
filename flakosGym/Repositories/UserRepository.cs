using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using flakosGym.Models;
using System.Data;
using System.Windows.Media.Effects;
using System.Security.Cryptography.X509Certificates;

namespace flakosGym.Repositories
{
    public class UserRepository: RepositoryBase, IUserRepository
    {

        public void Add(UserModel userModel)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO [User] VALUES (@Id, @Username, @Password, @Name, @LastName, @Email)";
                command.Parameters.AddWithValue("@Id", userModel.Id);
                command.Parameters.AddWithValue("@UserName", userModel.Username);
                command.Parameters.AddWithValue("@Name", userModel.Name);
                command.Parameters.AddWithValue("@Password", userModel.Password);
                command.Parameters.AddWithValue("@LastName", userModel.LastName);
                command.Parameters.AddWithValue("@Email", userModel.Email);
                command.ExecuteNonQuery();
                connection.Close(); 
            }
        }


      
        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool valiUser;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [User] where username=@username and [password]=@password";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = credential.Password;
                valiUser = command.ExecuteScalar() == null ? false : true;
            }
            return valiUser;
        }

        public void Edit(UserModel userModel)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<UserModel> GetByAll()
            {
                throw new NotImplementedException();
            }

            public UserModel GetById(int id)
            {
                throw new NotImplementedException();
            }

            public UserModel GetByUsername(string username)
            {
                UserModel user = null;
                using (var connection = GetConnection())
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "select * from [User] where username=@username";
                    command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new UserModel()
                            {
                                Id = reader[0].ToString(),
                                Username = reader[1].ToString(),
                                Password = string.Empty,
                                Name = reader[3].ToString(),
                                LastName = reader[4].ToString(),
                                Email = reader[5].ToString(),
                            };
                        }

                    }

                }
                return user;
            }
            public void Remove(int id)
            {
                throw new NotImplementedException();
            }
        }
    }
