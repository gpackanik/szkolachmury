using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using wwwPostgresSQL.Interfaces;
using Npgsql;
using wwwPostgresSQL.Models;

namespace wwwPostgresSQL.DAL
{
    public class PostgresDataAccess : IDataAccess
    {
        private string _connectionString;
        public PostgresDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<DataModel> Execute(string query)
        {
            var result = new List<DataModel>();
            using (var con = new NpgsqlConnection(_connectionString))
            {
                
                using (var cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = query;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(new DataModel
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Age = reader.GetInt32(2),
                            Address = reader.GetString(3),
                            Salary = (decimal)reader.GetDouble(4)
                        });
                    }

                }
            }

            return result;
        }
    }
}
