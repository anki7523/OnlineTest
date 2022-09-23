using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDataProcessing.DataAccess.Models
{
    public class EmployeesPayroll
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string? EmployeeName { get; set; }

        public DateTime PayPeriodStart { get; set; }
        public DateTime PayPeriodEnd { get; set; }
        public DateTime PayDate { get; set; }

        public string EarningHours { get; set; }
        public string GrossWages { get; set; }
        public int ClientPayrollId { get; set; }
        public bool IsProcessed { get; set; }

    }
}
