using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Conctants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Caching;
using Core.Aspect.Performance;
using Core.Aspect.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class MembershipManager : IMembershipService
    {
        IMembershipDal _membershipDal;
        ISubscriptionService _subscriptionService;

        public MembershipManager(IMembershipDal membershipDal, ISubscriptionService subscriptionService)
        {
            _membershipDal = membershipDal;
            _subscriptionService = subscriptionService; ;
        }

        [CacheRemoveAspect("IMembershipService.Get")]
        [SecuredOperation("product.add, admin")]
        [ValidationAspect(typeof(MembershipValidator))]
        public IResult Add(Membership membership)
        {
            IResult result = BusinessRules.Run(
                CheckIfMembershipDate(membership.SubsId)
                );
            if (result != null)
            {
                return result;
            }

            _membershipDal.Add(membership);
            return new SuccessResult(Messages.MembershipAdded);
        }

        [CacheRemoveAspect("IMembershipService.Get")]
        [SecuredOperation("product.add, admin")]
        [ValidationAspect(typeof(MembershipValidator))]
        public IResult Delete(Membership membership)
        {
            _membershipDal.Delete(membership);
            return new SuccessResult(Messages.MembershipDeleted);
        }

        [PerformanceAspect(2)]
        [CacheAspect]
        public IDataResult<Membership> Get(int id)
        {
            return new SuccessDataResult<Membership>(_membershipDal.Get(m => m.Id == id));
        }

        [PerformanceAspect(2)]
        [CacheAspect]
        public IDataResult<List<Membership>> GetAll()
        {
            return new SuccessDataResult<List<Membership>>(_membershipDal.GetAll(), Messages.MembershipsListed);
        }

        [PerformanceAspect(2)]
        [CacheAspect]
        public IDataResult<MembershipDetailDto> GetDetails(int id)
        {
            return new SuccessDataResult<MembershipDetailDto>(_membershipDal.GetDetails(m => m.Id == id).ToString());
        }

        [CacheRemoveAspect("IMembershipService.Get")]
        [SecuredOperation("product.add, admin")]
        [ValidationAspect(typeof(MembershipValidator))]
        public IResult Update(Membership membership)
        {
            var result = _membershipDal.GetAll(m => m.UserId == membership.UserId).Any();
            if (result)
            {
                _membershipDal.Update(membership);
                return new SuccessResult(Messages.MembershipUpdated);
            }

            return new ErrorResult(Messages.MembershipNotUpdated);
        }

        private IResult CheckIfMembershipDate(int subsId)
        {
            var result = _membershipDal.GetAll(m => m.SubsId == subsId).Any();
            var monthlySubscription = _subscriptionService.GetDetails("Aylık Üyelik").Data.Name;
            var sixMonthlySubscription = _subscriptionService.GetDetails("Altı Aylık Üyelik").Data.Name;
            var yearlySubscription = _subscriptionService.GetDetails("Yıllık Üyelik").Data.Name;
            var find = _membershipDal.GetDetails().SubsName;
            var day = _membershipDal.GetDetails().SubsDate = DateTime.Now;
            if (result)
            {
                if (find == monthlySubscription)
                {

                    var addDay = _membershipDal.GetDetails().SubsFinishDate == day.AddDays(30);
                }
                else if (find == sixMonthlySubscription)
                {
                    var addDay = _membershipDal.GetDetails().SubsFinishDate == day.AddDays(180);
                }
                else if (find == yearlySubscription)
                {
                    var addDay = _membershipDal.GetDetails().SubsFinishDate == day.AddDays(365);
                }

                return new SuccessResult();
            }

            return new ErrorResult();
        }
    }
}
