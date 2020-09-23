using AsyncWindowsApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWindowsApplication.Validation
{
    public static class GroupValid
    {
       public  static bool ValidateInsert(User user, string connectionString)
        {
            var sql = @"SELECT * FROM [dbo].[Group] WHERE Id = @Id";

            bool find = false;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", user.GroupId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            find = true;
                        }
                    }
                }

            }
            return find;
        }
    }
}
