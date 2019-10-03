using Domain.Main.Models;
using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Main.Interfaces
{
    public interface IIslemDbAppService<TEntity> : IAppService<TEntity>
    where TEntity : REntity
    {
        [RServiceInterceptorViewAttribute]
        void UseYnaLogServer();
        [RServiceInterceptorViewAttribute]
        void UseYnaLogTestServer();
        [RServiceInterceptorViewAttribute]
        void UseYnaLogTest2Server();
        [RServiceInterceptorViewAttribute]
        void UseYnaLogTest3Server();
    }
}
