using Entities.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class MembershipValidator : AbstractValidator<Membership>
    {
        public MembershipValidator()
        {
            //RuleFor(m => m.SubsPrice).GreaterThanOrEqualTo(90);
        }
    }
}
