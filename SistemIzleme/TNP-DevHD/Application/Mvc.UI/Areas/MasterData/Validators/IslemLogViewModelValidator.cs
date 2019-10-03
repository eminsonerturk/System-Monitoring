using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Rota2.ResourceProviders;
using Application.ViewModels.MasterData;

namespace Mvc.UI.Areas.MasterData.Validators
{
    public class IslemLogViewModelValidator : AbstractValidator<IslemLogViewModel>
    {
        public IslemLogViewModelValidator()
        {
            RuleFor(p => p.EntityName).NotEmpty().WithMessage(RResx.GetResource("MasterData", "ValidationRequired", RResx.GetResource("MasterData", "LabelName")));
            //RuleFor(p => p.EntityName).Length(0, 50).WithMessage
                //(RResx.GetResource("MasterData", "ValidationMaxLength", RResx.GetResource("MasterData", "LabelName"), 50));
        }
    }
}