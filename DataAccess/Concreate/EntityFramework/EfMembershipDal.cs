using Core.DataAccess.Concreate.EntityFramework;
using Core.Entities.Concreate;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.EntityFramework
{
    public class EfMembershipDal : EfEntityRepositoryBase<Membership, FitnessCenterContext>, IMembershipDal
    {
        public List<Subscription> GetSubscriptions(User user)
        {
            using (var context = new FitnessCenterContext())
            {
                var result = from subscription in context.Subscriptions
                             join member in context.Memberships on subscription.Id equals member.SubscriptionId
                             where member.UserId == user.Id
                             select new Subscription { Id = member.SubscriptionId, Name = member.SubscriptionName };

                return result.ToList();
            }
        }
    }
}

