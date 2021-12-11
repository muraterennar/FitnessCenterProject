using Business.Abstract;
using Business.Conctants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class SubscriptionManager : ISubscriptionService
    {
        ISubscriptionDal _subscriptionDal;

        public SubscriptionManager(ISubscriptionDal subscriptionDal)
        {
            _subscriptionDal = subscriptionDal;
        }

        public IResult Add(Subscription subscription)
        {
            _subscriptionDal.Add(subscription);
            return new SuccessResult(Messages.SubsAdded);
        }

        public IResult Delete(Subscription subscription)
        {
            _subscriptionDal.Delete(subscription);
            return new SuccessResult(Messages.SubsDeleted);
        }

        public IDataResult<Subscription> Get(int id)
        {
            return new SuccessDataResult<Subscription>(_subscriptionDal.Get(s => s.Id == id), Messages.SubscriptionListed);
        }

        public IDataResult<List<Subscription>> GetAll()
        {
            return new SuccessDataResult<List<Subscription>>(_subscriptionDal.GetAll(), Messages.SubscriptionsListed);
        }

        public IDataResult<Subscription> GetDetails(string subsName)
        {
            return new SuccessDataResult<Subscription>(_subscriptionDal.GetDetails(s => s.Name == subsName));
        }

        public IResult Update(Subscription subscription)
        {
            var result = _subscriptionDal.GetAll(s => s.Id == subscription.Id).Any();
            if (result)
            {
                _subscriptionDal.Update(subscription);
                return new SuccessResult(Messages.SubsUpdated);
            }

            return new ErrorResult(Messages.SubsNotUpdated);
        }
    }
}
