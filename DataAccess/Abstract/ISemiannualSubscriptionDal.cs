using Core.DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ISemiannualSubscriptionDal : IEntityRepository<SemiannualSubscription>
    {
        
    }
}
