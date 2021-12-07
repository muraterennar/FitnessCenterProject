using Core.DataAccess.Concreate.EntityFramework;
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
        public List<MembershipDetailDto> GetMembershipsDetails()
        {
            using (FitnessCenterContext context = new FitnessCenterContext())
            {
                var result = from membership in context.Memberships
                             join salary in context.SalarySubscriptions on membership.SubscriptionId equals salary.Id
                             join semiannual in context.SemiannualSubscriptions on membership.SubscriptionId equals semiannual.Id
                             join annual in context.AnnualSubscriptions on membership.SubscriptionId equals annual.Id
                             select new MembershipDetailDto
                             {
                                 SalarySubscriptionId = salary.Id,
                                 SalarySubscriptionName = salary.SalarySubscriptionName,
                                 SalarySubscriptionDescription = salary.SalarySubscriptionDescription,
                                 SalarySubscriptionPrice = salary.SalarySubscriptionPrice,

                                 SemiannualSubscriptionId = semiannual.Id,
                                 SemiannualSubscriptionName = semiannual.SemiannualSubscriptionName,
                                 SemiannualSubscriptionDescription = semiannual.SemiannualSubscriptionsDescription,
                                 SemiannualSubscriptionPrice = semiannual.SemiannualSubscriptionsPrice,

                                 AnnualSubscriptionId = annual.Id,
                                 AnnualSubscriptionName = annual.AnnualSubscriptionName,
                                 AnnualSubscriptionDescription = annual.AnnualSubscriptionsDescription,
                                 AnnualSubscriptionPrice = annual.AnnualSubscriptionsPrice
                             };

                return result.ToList();
            }
        }
    }
}

