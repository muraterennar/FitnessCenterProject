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
    public class EfSalarySubsriptionDal : EfEntityRepositoryBase<SalarySubscription, FitnessCenterContext>, ISalarySubscriptionDal
    {
        
    }
}
