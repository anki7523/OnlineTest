using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.DataAccess.Interfaces
{
    public interface IDbRepository
    {
        IDbConnection CreateConnection();
        IDbConnection CreateConnection(string connectionString);
    }
}
