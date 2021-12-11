using Core.Utilities.Results;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISubscriptionService
    {
        IDataResult<List<Subscription>> GetAll();
        IDataResult<Subscription> Get(int id);
        IDataResult<Subscription> GetDetails(string subsName);
        IResult Add(Subscription subscription);
        IResult Delete(Subscription subscription);
        IResult Update(Subscription subscription);

    }
}
