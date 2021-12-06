using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate
{
    public class SalarySubscription : IEntity
    {
        public int Id { get; set; }
        public string SalarySubscriptionName { get; set; }
        public decimal SalarySubscriptionPrice { get; set; }
        public string SalarySubscriptionDescription { get; set; }
    }
}
