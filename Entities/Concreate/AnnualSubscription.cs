using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate
{
    public class AnnualSubscription : IEntity
    {
        public int Id { get; set; }
        public string AnnualSubscriptionName { get; set; }
        public decimal AnnualSubscriptionsPrice { get; set; }
        public string AnnualSubscriptionsDescription { get; set; }
    }
}
