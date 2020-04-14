using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Task6.Services
{
    public class SqlDbService : IDbService
    {
        string con = "Data Source=db-mssql;Initial Catalog=s19183;Integrated Security=True";

        public bool CheckStudent(string index)
        {
            bool result;
            using (var connection = new SqlConnection(con))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Student WHERE index = @index";
                command.Parameters.AddWithValue("index", index);
                connection.Open();
                var dr = command.ExecuteReader();

                result = dr.Read();
            }
            return result;
        }
    }
}
