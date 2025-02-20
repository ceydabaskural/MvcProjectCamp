using FluentValidation;
using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Email address is required.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject is required.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Content is required.");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("A valid email address is required.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Enter min. 3 characters");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Enter max. 100 characters");
        }
    }
}
