using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Rota2.ResourceProviders;
using Application.ViewModels.Envanter;

namespace Mvc.UI.Areas.Envanter.Validators
{
    public class ServerCrudViewModelValidator : AbstractValidator<ServerCrudViewModel>
    {
        public ServerCrudViewModelValidator()
        {
            RuleFor(p => p.ServerIp).NotEmpty().WithMessage(RResx.GetResource("Control", "ValidationRequired", RResx.GetResource("Envanter", "LabelServerIp")));
            RuleFor(p => p.ComputerName).NotEmpty().WithMessage(RResx.GetResource("Control", "ValidationRequired", RResx.GetResource("Envanter", "LabelComputerName")));
            RuleFor(p => p.ComputerName).Length(0, 20).WithMessage(RResx.GetResource("Control", "ValidationMaxLength", RResx.GetResource("Envanter", "LabelComputerName"), 20));
        }
    }
}