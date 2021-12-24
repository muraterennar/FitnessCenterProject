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
        IDataResult<Membership> Get(int id);
        IDataResult<List<MembershipDetailDto>> GetDetails(int userId);
        IResult Add(Membership membership);
        IResult Delete(Membership membership);
        IResult Update(Membership membership);
    }
}
