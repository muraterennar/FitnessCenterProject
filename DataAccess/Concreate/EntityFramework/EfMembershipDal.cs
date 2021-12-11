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
        public MembershipDetailDto GetDetails()
        {
            using (FitnessCenterContext context = new FitnessCenterContext())
            {
                var result = from member in context.Memberships
                             join subs in context.Subscriptions on member.SubsId equals subs.Id
                             join user in context.Users on member.UserId equals user.Id

                             select new MembershipDetailDto
                             {
                                 UserId = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 SubsName = subs.Name,
                                 SubsPrice = member.SubsPrice,
                                 SubsDate = member.SubsDate,
                                 SubsFinishDate = member.SubsFinishDate
                             };
                return result.FirstOrDefault();

            }
        }
    }
}
