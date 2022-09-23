using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDataProcessing.DataAccess.Models
{
    public class CompanyPayroll
    {
        public string FileName { get; set; }
        public int Id { get; set; }
        public string ProviderName { get; set; }

        public int CompanyId { get; set; }
    }
}
