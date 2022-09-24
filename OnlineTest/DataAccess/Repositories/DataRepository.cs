using Dapper;
using OnlineTest.DataAccess.Interfaces;
using OnlineTest.Data;
using System.Data;
using OnlineTest.Models;
using System.ComponentModel.Design;

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


        public async Task<long> AddUser(UserSignupModel user)
        {
            using (var connection = _db.CreateConnection())
            {
                var createdDate = DateTime.Now;
                var Id = await connection.ExecuteScalarAsync<int>(@"INSERT INTO Users(Name, Mobile, Address, State, Country,CreatedDate)
                       VALUES(@Name, @Mobile, @Address, @State, @Country,@createdDate);SELECT SCOPE_IDENTITY()", new { user.Name, user.Mobile, user.Address, user.State, user.Country, createdDate });
                return Id;

            }
        }

        public async Task<long> CheckUser(string mobile)
        {
            using (var connection = _db.CreateConnection())
            {
                var id = await connection.QueryFirstOrDefaultAsync<long>(@"select ID from Users where Mobile = @mobile", new { mobile });
                return id;

            }
        }

        public async Task<long> CheckUsersAnswers(long userID)
        {
            using (var connection = _db.CreateConnection())
            {
                var id = await connection.QueryFirstOrDefaultAsync<long>(@"select Top(1) ID from UsersAnswer where UserID = @userID", new { userID });
                return id;

            }
        }
    }
}
