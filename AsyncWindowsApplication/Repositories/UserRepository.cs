﻿using AsyncWindowsApplication.Models;
using AsyncWindowsApplication.Repositories.Abstractions;
using AsyncWindowsApplication.Validation;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncWindowsApplication.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string connectionString;

        public event EventHandler<ErrorEventArgs> NotifyClientErrorEvent;

        public UserRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<int> Create(User user)
        {
            
                var UserSql = @"INSERT INTO [dbo].[User]
                               ([Name],
                               [Age],
                               [GroupId])
                         VALUES
                               (@Name
                               ,@Age
                               ,@GroupId);
                        SET @id=SCOPE_IDENTITY()";
            
                try
                {
                if (!GroupValid.ValidateInsert(user, this.connectionString))
                {
                    throw new Exception("No Group whith this id");
                }
                using (var connection = new SqlConnection(this.connectionString))
                    {
                        await connection.OpenAsync();


                        using (var command = connection.CreateCommand())
                        {

                            command.CommandText = UserSql;

                            command.Parameters.AddWithValue("@Name", user.Name);
                            command.Parameters.AddWithValue("@Age", user.Age);
                            command.Parameters.AddWithValue("@GroupId", user.GroupId);

                            var idParam = new SqlParameter
                            {
                                ParameterName = "id",
                                Direction = System.Data.ParameterDirection.Output,
                                SqlDbType = System.Data.SqlDbType.Int
                            };

                            command.Parameters.Add(idParam);

                            if (await command.ExecuteNonQueryAsync() == 0)
                                throw new Exception("No changes in db");

                            return Convert.ToInt32(idParam.Value);
                        }
                    }
                }

                catch (DbException ex)
                {
                    var error = new Exception("DbError", ex);
                    this.NotifyClientErrorEvent.Invoke(this, new ErrorEventArgs(error));
                    Log.Logger.Error(error.ToString());
                }
                catch (Exception ex)
                {
                    this.NotifyClientErrorEvent.Invoke(this, new ErrorEventArgs(ex));
                    Log.Logger.Error(ex.ToString());
                }


                return 0;
            
        }
        public async Task  Delete(int Id)
        {
            var sql = @"DELETE FROM [dbo].[User]
                     WHERE Id = @Id";
            try
            {
                using(var connection =new SqlConnection(this.connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = sql;
                        command.Parameters.AddWithValue("@Id", Id);
                        if (await command.ExecuteNonQueryAsync()==0)
                            throw new Exception("No chages in db(Delete)");
                        return;
                    }
                }
            }
            
            catch (DbException ex)
            {
                var error = new Exception("DbError", ex);
                this.NotifyClientErrorEvent.Invoke(this, new ErrorEventArgs(error));
                Log.Logger.Error(error.ToString());
            }
            catch (Exception ex)
            {
                this.NotifyClientErrorEvent.Invoke(this, new ErrorEventArgs(ex));
                Log.Logger.Error(ex.ToString());
            }
        }

        public async Task<IEnumerable<User>> Get()
        {
            List<User> users = new List<User>();

            var sql = @"SELECT * FROM [User]";

            try
            {
                using (var connection = new SqlConnection(this.connectionString))
                {
                    await connection.OpenAsync();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = sql;

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                users.Add(new User
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = reader["Name"].ToString(),
                                    Age = Convert.ToInt32(reader["Age"]),
                                    GroupId= Convert.ToInt32(reader["GroupId"])
                                });
                            }
                        }
                    }
                }
            }
            catch (DbException ex)
            {
                var error = new Exception("DbError", ex);
                this.NotifyClientErrorEvent.Invoke(this, new ErrorEventArgs(error));
                Log.Logger.Error(error.ToString());
            }
            catch (Exception ex)
            {
                this.NotifyClientErrorEvent.Invoke(this, new ErrorEventArgs(ex));
                Log.Logger.Error(ex.ToString());
            }
            return users;
        }

        public async Task Update(User user)
        {
            var sql = @"UPDATE [dbo].[User] SET [Name] = @Name, [Age] = @Age,[GroupId]=@GroupId WHERE Id = @Id";
            try
            {
                using (var connection = new SqlConnection(this.connectionString))
                {
                    await connection.OpenAsync();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = sql;
                        command.Parameters.AddWithValue("@Id", user.Id);
                        command.Parameters.AddWithValue("@Name", user.Name);
                        command.Parameters.AddWithValue("@Age", user.Age);
                        command.Parameters.AddWithValue("@GroupId", user.GroupId);



                        if (await command.ExecuteNonQueryAsync() == 0)
                            throw new Exception("No changes in db(Update)");
                        return;
                        
                    }
                }
            }
            catch (DbException ex)
            {
                var error = new Exception("DbError", ex);
                this.NotifyClientErrorEvent.Invoke(this, new ErrorEventArgs(error));
                Log.Logger.Error(error.ToString());
            }
            catch (Exception ex)
            {
                this.NotifyClientErrorEvent.Invoke(this, new ErrorEventArgs(ex));
                Log.Logger.Error(ex.ToString());
            }
   
        }
    }
}
