using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Rota2.ResourceProviders;
using Application.ViewModels.Envanter;

namespace Mvc.UI.Areas.Envanter.Validators
{
    public class LokasyonCrudViewModelValidator : AbstractValidator<LokasyonCrudViewModel>
    {
        public LokasyonCrudViewModelValidator()
        {
            RuleFor(p => p.Ad).NotEmpty().WithMessage(RResx.GetResource("Control", "ValidationRequired", RResx.GetResource("Envanter", "LabelLokasyonAd")));
            RuleFor(p => p.Ad).Length(0, 20).WithMessage(RResx.GetResource("Control", "ValidationMaxLength", RResx.GetResource("Envanter", "LabelLokasyonAd"), 20));
        }
    }
}