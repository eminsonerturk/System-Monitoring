using Application.ViewModels.Islem;
using Domain.Main.Models;
using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Main.Interfaces
{
    public interface IEntityFieldNameAppService : IIslemDbAppService<EntityFieldName>
    {
        List<string> GetEntityFieldList(IslemLogSearchViewModel searchModel);
    }
}
