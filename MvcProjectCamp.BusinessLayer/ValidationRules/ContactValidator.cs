using FluentValidation;
using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Email address is required.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Enter min. 3 characters.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Enter max. 50 characters.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject is required.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required.");
        }
    }
}
