using AsyncWindowsApplication.Models;
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
    public class GroupRepository : IGroupRepository
    {
        private readonly string connectionString;

        public event EventHandler<ErrorEventArgs> NotifyClientErrorEvent;

        public GroupRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async  Task<int> Create(Group group)
        {
            var sql = @"INSERT INTO [dbo].[Group]
                               ([Title])
                         VALUES
                               (@Title);
                        SET @id=SCOPE_IDENTITY()";

            try
            {
                using (var connection = new SqlConnection(this.connectionString))
                {
                    await connection.OpenAsync();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = sql;

                        command.Parameters.AddWithValue("@Title",group.Title);


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

        public async Task Delete(int id)
        {
            var sql = @"DELETE FROM [dbo].[Group]
                     WHERE Id = @Id";
            try
            {
                using (var connection = new SqlConnection(this.connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = sql;
                        command.Parameters.AddWithValue("@Id", id);
                        if (await command.ExecuteNonQueryAsync() == 0)
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

        public async Task<IEnumerable<Group>> Get()
        {
            List<Group> groups = new List<Group>();

            var sql = @"SELECT * FROM [Group]";

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
                                groups.Add(new Group
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Title = reader["Title"].ToString()
                                  
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
            return groups;
        }
            public async Task Update(Group group)
        {
            var sql = @"UPDATE [dbo].[Group] SET [Title] = @Title  WHERE Id = @Id";
            try
            {
                using (var connection = new SqlConnection(this.connectionString))
                {
                    await connection.OpenAsync();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = sql;
                        command.Parameters.AddWithValue("@Title", group.Title);
                        command.Parameters.AddWithValue("@Id", group.Id);




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
