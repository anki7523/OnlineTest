using OnlineTest.Data;
using OnlineTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.DataAccess.Interfaces
{
    public interface IDataRepository
    {
        Task<List<StateWiseResult>> GetStateWiseResult();
        Task<long> AddUser(UserSignupModel user);
        Task<long> CheckUser(string mobile);
        Task<long> CheckUsersAnswers(long userID);
    }
}
