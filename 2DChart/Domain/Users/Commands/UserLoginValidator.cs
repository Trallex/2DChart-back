using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace _2DChart.Domain.Users.Commands
{
    public class UserLoginValidator : AbstractValidator<UserLoginCommand>
    {
        public UserLoginValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty()
                .WithMessage("Username must not be empty")
                .MaximumLength(50)
                ;

            RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage("Password must not be empty")
                .NotEqual(user => user.Name)
                ;
        }
    }
    public class UserRegisterValidator : AbstractValidator<UserRegisterCommand>
    {
        public UserRegisterValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty()
                .WithMessage("Username must not be empty")
                .MaximumLength(50)
                ;

            RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage("Password must not be empty")
                .MaximumLength(50)
                .NotEqual(user => user.Name)
                ;
            RuleFor(user => user.Mail)
                .NotEmpty()
                .WithMessage("Email must not be empty")
                .EmailAddress()
               
                ;
        }
    }
}
