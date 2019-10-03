using Application.ViewModels.Envanter;
using FluentValidation;
using Rota2.ResourceProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.UI.Areas.Envanter.Validators
{
    public class KullaniciViewModelValidator : AbstractValidator<KullaniciCrudViewModel>
    {
        public KullaniciViewModelValidator()
        {
            RuleFor(p => p.KullaniciEMail).NotEmpty().WithMessage(RResx.GetResource("Control", "ValidationRequired", RResx.GetResource("Envanter", "LabelKullaniciEmail")));
            RuleFor(p => p.KullaniciAd).NotEmpty().WithMessage(RResx.GetResource("Control", "ValidationRequired", RResx.GetResource("Envanter", "LabelKullaniciAd")));
            RuleFor(p => p.IsAdmin).NotEmpty().WithMessage(RResx.GetResource("Control", "ValidationRequired", RResx.GetResource("Envanter", "LabelIsAdmin")));
        }
    }
}