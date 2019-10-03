using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Rota2.ResourceProviders;
using Application.ViewModels.Envanter;

namespace Mvc.UI.Areas.Envanter.Validators
{
    public class ServerTipiCrudViewModelValidator : AbstractValidator<ServerTipiCrudViewModel>
    {
        public ServerTipiCrudViewModelValidator()
        {
            RuleFor(p => p.Ad).NotEmpty().WithMessage(RResx.GetResource("Control", "ValidationRequired", RResx.GetResource("Envanter", "LabelServerTipiAd")));
            RuleFor(p => p.Ad).Length(0, 20).WithMessage(RResx.GetResource("Control", "ValidationMaxLength", RResx.GetResource("Envanter", "LabelServerTipiAd"), 20));
        }
    }
}