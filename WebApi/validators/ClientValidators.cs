using Core.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.validators
{
    public class ClientValidators : AbstractValidator<Client>
    {
        public ClientValidators()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Please enter Name.");

            RuleFor(p => p.CloudProviderId).NotEmpty().WithMessage("Must be 1 or 2.");
        }
    }
}
