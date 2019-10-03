using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Rota2.ResourceProviders;
using Application.ViewModels.Envanter;

namespace Mvc.UI.Areas.Envanter.Validators
{
    public class OperatingSystemCrudViewModelValidator : AbstractValidator<OperatingSystemCrudViewModel>
    {
        public OperatingSystemCrudViewModelValidator()
        {
            RuleFor(p => p.Ad).NotEmpty().WithMessage(RResx.GetResource("Control", "ValidationRequired", RResx.GetResource("Envanter", "LabelOperatingSystemAd")));
            RuleFor(p => p.Ad).Length(0, 1000).WithMessage(RResx.GetResource("Control", "ValidationMaxLength", RResx.GetResource("Envanter", "LabelOperatingSystemAd"), 1000));
        }
    }
}