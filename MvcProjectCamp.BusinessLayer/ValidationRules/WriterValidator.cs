using FluentValidation;
using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Author name is required.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Author surname is required.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("About is required.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Enter min. 2 characters.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Enter max. 3 characters.");
            //RuleFor(x => x.WriterName).Must();
        }
    }
}
