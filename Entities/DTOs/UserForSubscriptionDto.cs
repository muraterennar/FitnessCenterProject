using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserForSubscriptionDto:IDto
    {
        public int UserId { get; set; }
        public int SubscriptionId { get; set; }
    }
}
