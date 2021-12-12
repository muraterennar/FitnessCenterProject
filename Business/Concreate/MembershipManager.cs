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
        decimal _monthlyPrice;
        decimal _sixMonthlyPrice;
        decimal _yearlyPrice;

        public MembershipManager(IMembershipDal membershipDal)
        {
            _membershipDal = membershipDal;
        }

        public MembershipManager(IMembershipDal membershipDal, decimal monthlyPrice = 150, decimal sixMonthlyPrice = 600, decimal yearlyPrice = 1080)
        {
            _membershipDal = membershipDal;
            _monthlyPrice = monthlyPrice;
            _sixMonthlyPrice = sixMonthlyPrice;
            _yearlyPrice = yearlyPrice;
        }

        [CacheRemoveAspect("IMembershipService.Get")]
        [SecuredOperation("product.add, admin")]
        [ValidationAspect(typeof(MembershipValidator))]
        public IResult Add(Membership membership)
        {
            IResult result = BusinessRules.Run(
                CheckIfMembershipUser(membership.UserId)
                );
            if (result != null)
            {
                return result;
            }

            if (membership.SubsId == 1)
            {
                membership.SubsDate = DateTime.Now;
                membership.SubsFinishDate = membership.SubsDate.AddDays(30);
                membership.SubsPrice = _monthlyPrice;
            }
            else if (membership.SubsId == 2)
            {
                membership.SubsDate = DateTime.Now;
                membership.SubsFinishDate = membership.SubsDate.AddDays(180);
                membership.SubsPrice = _sixMonthlyPrice;
            }
            else if (membership.SubsId == 3)
            {
                membership.SubsDate = DateTime.Now;
                membership.SubsFinishDate = membership.SubsDate.AddDays(365);
                membership.SubsPrice = _yearlyPrice;
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

        private IResult CheckIfMembershipUser(int userId)
        {
            var find = _membershipDal.GetAll(m => m.UserId == userId).Any();
            if (find)
            {
                return new ErrorResult(Messages.UserIdAlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
