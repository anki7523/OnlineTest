using OnlineTest.Data;
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
    }
}
