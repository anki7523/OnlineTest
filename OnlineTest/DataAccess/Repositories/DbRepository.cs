using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OnlineTest.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.DataAccess.Repositories
{
    internal class DbRepository : IDbRepository
    {
        private readonly IConfiguration _config;
        public DbRepository( IConfiguration config)
        {
            _config = config;
        }
        public IDbConnection CreateConnection() => new SqlConnection(_config.GetConnectionString("DefaultConnection"));

        public IDbConnection CreateConnection(string connectionString) => new SqlConnection(connectionString);

    }
}
