using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate
{
    public class SemiannualSubscription : IEntity
    {
        public int Id { get; set; }
        public string SemiannualSubscriptionName { get; set; }
        public decimal SemiannualSubscriptionsPrice { get; set; }
        public string SemiannualSubscriptionsDescription { get; set; }
    }
}
