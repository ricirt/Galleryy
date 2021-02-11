using FluentValidation;
using Gallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gallery.Validators
{
public class LoginModelValidator:AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            RuleFor(x => x.Username).NotNull().WithMessage("Lütfen geçerli değer gir").NotEmpty().WithMessage("Lütfen Boş girmeyiniz");
            RuleFor(x => x.Password).NotNull().WithMessage("Lütfen geçerli password gir").NotEmpty().WithMessage("Lütfen password gir");
        }
    }

}
