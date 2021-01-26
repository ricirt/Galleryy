using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gallery.ViewModels.Validators
{
    public class ProfilViewModelValidator:AbstractValidator<ProfilViewModel>
    {
        public ProfilViewModelValidator()
        {
            RuleFor(x => x.UName).NotEmpty().WithMessage("User name boş olamaz")
                .NotNull().WithMessage("User name null olamaz")
                .MaximumLength(50).WithMessage("50 karakterden fazla olamaz");
            RuleFor(x=>x.Umail).NotEmpty().WithMessage("User name boş olamaz")
                .NotNull().WithMessage("E mail boş oalmaz").
                EmailAddress().WithMessage("Email adress  formatını uygun giriniz");                
        }
    }
}
