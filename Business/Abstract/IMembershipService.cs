using Core.Entities.Concreate;
using Core.Utilities.Results;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMembershipService
    {
        IDataResult<List<Membership>> GetAll();
        IDataResult<List<Membership>> Get(int id);
        IDataResult<List<Subscription>> GetSubscriptions(User user);
        IResult Add(Membership membership);
        IResult Update(Membership membership);
        IResult Delete(Membership membership);
    }
}
