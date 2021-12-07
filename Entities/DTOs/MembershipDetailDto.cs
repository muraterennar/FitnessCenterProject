using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class MembershipDetailDto : IDto
    {
        public int SalarySubscriptionId { get; set; }
        public string SalarySubscriptionName { get; set; }
        public decimal SalarySubscriptionPrice { get; set; }
        public string SalarySubscriptionDescription { get; set; }

        public int SemiannualSubscriptionId { get; set; }
        public string SemiannualSubscriptionName { get; set; }
        public decimal SemiannualSubscriptionPrice { get; set; }
        public string SemiannualSubscriptionDescription { get; set; }

        public int AnnualSubscriptionId { get; set; }
        public string AnnualSubscriptionName { get; set; }
        public decimal AnnualSubscriptionPrice { get; set; }
        public string AnnualSubscriptionDescription { get; set; }
    }
}
