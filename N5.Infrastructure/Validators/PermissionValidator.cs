using FluentValidation;
using N5.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.Infrastructure.Validators
{
    public class PermissionValidator : AbstractValidator<PermissionDto>
    {
        public PermissionValidator()
        {
            RuleFor(permission => permission.Name)
                .NotNull()
                .Length(3,29);
            RuleFor(permission => permission.LastName)
                .NotNull()
                .Length(3, 29);
            RuleFor(permission => permission.IdTypePermission)
                .NotNull()
                .NotEmpty()
                .NotEqual(0);
        }
    }
}
