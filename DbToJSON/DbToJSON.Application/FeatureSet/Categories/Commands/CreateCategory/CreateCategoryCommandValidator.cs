using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DbToJSON.Application.FeatureSet.Categories.Commands.CreateCategory
{
    internal class CreateCategoryCommandValidator : AbstractValidator<CreateCateogoryCommand>
    {
        public CreateCategoryCommandValidator() =>
                RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} is needed!")
                .NotNull()
                .MaximumLength(25).WithMessage("{PropertyName} must not exceed 12 characters!");
    }
}
