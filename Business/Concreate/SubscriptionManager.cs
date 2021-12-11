using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Conctants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Caching;
using Core.Aspect.Performance;
using Core.Aspect.Validation;
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

        [CacheRemoveAspect("ISubscriptionService.Get")]
        [SecuredOperation("product.add, admin")]
        [ValidationAspect(typeof(SubscriptionValidator))]
        public IResult Add(Subscription subscription)
        {
            _subscriptionDal.Add(subscription);
            return new SuccessResult(Messages.SubsAdded);
        }

        [CacheRemoveAspect("ISubscriptionService.Get")]
        [SecuredOperation("product.add, admin")]
        [ValidationAspect(typeof(SubscriptionValidator))]
        public IResult Delete(Subscription subscription)
        {
            _subscriptionDal.Delete(subscription);
            return new SuccessResult(Messages.SubsDeleted);
        }

        [PerformanceAspect(2)]
        [CacheAspect]
        public IDataResult<Subscription> Get(int id)
        {
            return new SuccessDataResult<Subscription>(_subscriptionDal.Get(s => s.Id == id), Messages.SubscriptionListed);
        }

        [PerformanceAspect(2)]
        [CacheAspect]
        public IDataResult<List<Subscription>> GetAll()
        {
            return new SuccessDataResult<List<Subscription>>(_subscriptionDal.GetAll(), Messages.SubscriptionsListed);
        }

        [PerformanceAspect(2)]
        [CacheAspect]
        public IDataResult<Subscription> GetDetails(string subsName)
        {
            return new SuccessDataResult<Subscription>(_subscriptionDal.GetDetails(s => s.Name == subsName));
        }

        [CacheRemoveAspect("ISubscriptionService.Get")]
        [SecuredOperation("product.add, admin")]
        [ValidationAspect(typeof(SubscriptionValidator))]
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
