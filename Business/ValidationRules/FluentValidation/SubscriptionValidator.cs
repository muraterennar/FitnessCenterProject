using Entities.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class SubscriptionValidator:AbstractValidator<Subscription>
    {
        public SubscriptionValidator()
        {
            RuleFor(s => s.Name).MinimumLength(6);
        }
    }
}
