using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate
{
    public class Membership : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SubscriptionId { get; set; }
        public string SubscriptionName { get; set; }
        public DateTime SubsriptionDate { get; set; }
    }
}
