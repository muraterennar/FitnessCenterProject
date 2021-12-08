using Core.DataAccess.Abstract;
using Core.Entities.Concreate;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IMembershipDal : IEntityRepository<Membership>
    {
         List<Subscription> GetSubscriptions(User user);
    }
}
