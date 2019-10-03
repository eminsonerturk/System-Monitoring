using Application.ViewModels.Elmah;
using Domain.Main.Models;
using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Main.Interfaces
{
    public interface IElmahErrorAppService:IElmahDbAppService<ElmahError>
    {
        List<string> GetApplicationList();
        string GetAllXml(string errorId);
    }
}
