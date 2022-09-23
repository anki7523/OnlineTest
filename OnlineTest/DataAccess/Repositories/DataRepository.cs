using Dapper;
using OnlineTest.DataAccess.Interfaces;
using OnlineTest.Data;
using System.Data;

namespace OnlineTest.DataAccess.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly IDbRepository _db;
        public DataRepository(IDbRepository db)
        {
            _db = db;
        }

        public async Task<List<StateWiseResult>> GetStateWiseResult()
        {
            using (var connection = _db.CreateConnection())
            {
                string spname = "spGetStateWiseWinner";
                var data = await connection.QueryAsync<StateWiseResult>(spname, commandType: CommandType.StoredProcedure);
                return data.ToList();
            }
        }

    }
}
