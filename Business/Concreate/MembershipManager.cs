using Business.Abstract;
using Business.Conctants;
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

        public MembershipManager(IMembershipDal membershipDal)
        {
            _membershipDal = membershipDal;
        }

        public IResult Add(Membership membership)
        {
            _membershipDal.Add(membership);
            return new SuccessResult(Messages.MembershipAdded);
        }

        public IResult Delete(Membership membership)
        {
            _membershipDal.Delete(membership);
            return new SuccessResult(Messages.MembershipDeleted);
        }

        public IDataResult<List<Membership>> Get(int id)
        {
            return new SuccessDataResult<List<Membership>>(_membershipDal.Get(m => m.Id == id).ToString());
        }

        public IDataResult<List<Membership>> GetAll()
        {
            return new SuccessDataResult<List<Membership>>(_membershipDal.GetAll());
        }

        public IDataResult<List<MembershipDetailDto>> GetMembershipDetailDto(int id)
        {
            return new SuccessDataResult<List<MembershipDetailDto>>(_membershipDal.GetMembershipsDetails(), Messages.MembershipDetailsListed);
        }

        public IResult Update(Membership membership)
        {
            var result = _membershipDal.GetAll(m => m.Id == membership.Id).Any();

            if (!result)
            {
                return new ErrorResult(Messages.MembershipNotUpdated);
            }

            _membershipDal.Update(membership);
            return new SuccessResult(Messages.MembershipUpdated);
        }
    }
}
