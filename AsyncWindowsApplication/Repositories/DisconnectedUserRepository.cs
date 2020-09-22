using AsyncWindowsApplication.CustomEventArgs;
using AsyncWindowsApplication.Models;
using AsyncWindowsApplication.Repositories.Abstractions;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWindowsApplication.Repositories
{
    public class DisconnectedUserRepository : IUserRepository
    {
        private readonly string sqlQuery;
        private readonly string connectionString;

        public DisconnectedUserRepository(string connectionString)
        {
            this.connectionString = connectionString;

            this.sqlQuery = "SELECT * FROM [User]";
        }

        public event EventHandler<ErrorEventArgs> NotifyClientErrorEvent;
        public event EventHandler<NotifyInsertEventArgs> NotifyInsertEvent;

        public async Task Create(User user)
        {
            try
            {
                using (var connection = new SqlConnection(this.connectionString))
                {
                    await connection.OpenAsync();

                    var adapter = new SqlDataAdapter("SELECT [Name], [Age] FROM [User]", connection);

                    var table = new DataTable("Users");

                    adapter.Fill(table);

                    var newRow = table.NewRow();

                    newRow["Name"] = user.Name;
                    newRow["Age"] = user.Age;

                    table.Rows.Add(newRow);

                    //adapter.RowUpdated += (sender, args) =>
                    //    this.NotifyInsertEvent.Invoke(this, 
                    //    new NotifyInsertEventArgs(Convert.ToInt32(args.Row["Id"]))); 

                    adapter.Update(table);

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
            var users = new List<User>();

            try
            {
                using (var connection = new SqlConnection(this.connectionString))
                {
                    await connection.OpenAsync();

                    var adapter = new SqlDataAdapter(this.sqlQuery, connection);

                    var table = new DataTable("Users");

                    adapter.Fill(table);

                    using (var reader = table.CreateDataReader())
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
            throw new NotImplementedException();
        }
    }
}
