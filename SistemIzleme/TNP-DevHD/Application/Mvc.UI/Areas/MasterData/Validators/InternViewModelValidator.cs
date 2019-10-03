using Domain.Main.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rota2.ResourceProviders;

namespace Domain.Main.Validator
{
    /*public class InternValidator: AbstractValidator<Intern>
    {
        public InternValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage(RResx.GetResource("MasterData", "ValidationRequired", RResx.GetResource("MasterData", "LabelName")));
            RuleFor(p => p.Name).Length(0, 2).WithMessage
                (RResx.GetResource("MasterData", "ValidationMaxLength", RResx.GetResource("MasterData", "LabelName"), 50));
        }
    }*/
}
