using AsyncWindowsApplication.CustomEventArgs;
using AsyncWindowsApplication.Models;
using AsyncWindowsApplication.Repositories.Abstractions;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWindowsApplication.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string connectionString;

        public event EventHandler<ErrorEventArgs> NotifyClientErrorEvent;
        public event EventHandler<NotifyInsertEventArgs> NotifyInsertEvent;

        public UserRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task Create(User user)
        {
            var sql = @"INSERT INTO [dbo].[User]
                               ([Name]
                               ,[Age])
                         VALUES
                               (@Name
                               ,@Age);
                        SET @id=SCOPE_IDENTITY()";

            try
            {
                using (var connection = new SqlConnection(this.connectionString))
                {
                    await connection.OpenAsync();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = sql;

                        command.Parameters.AddWithValue("@Name", user.Name);
                        command.Parameters.AddWithValue("@Age", user.Age);

                        var idParam = new SqlParameter
                        {
                            ParameterName = "id",
                            Direction = System.Data.ParameterDirection.Output,
                            SqlDbType = System.Data.SqlDbType.Int
                        };

                        command.Parameters.Add(idParam);

                        if (await command.ExecuteNonQueryAsync() == 0) 
                            throw new Exception("No changes in db");

                        this.NotifyInsertEvent.Invoke(this, new NotifyInsertEventArgs( Convert.ToInt32(idParam.Value)));
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

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
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
                                    Age = Convert.ToInt32(reader["Age"])
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
            var sql = @"UPDATE [dbo].[User]
                           SET [Name] = @Name
                              ,[Age] = @Age
                         WHERE Id = @Id";

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

                        if (await command.ExecuteNonQueryAsync() == 0) throw new Exception("No changes in db");
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
