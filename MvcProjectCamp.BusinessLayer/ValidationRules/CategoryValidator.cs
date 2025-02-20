using FluentValidation;
using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category Name is required.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Enter min. 3 characters.");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Enter max. 3 characters.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
        }
    }
}
