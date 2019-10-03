using Domain.Main.Models;
using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Main.Interfaces
{
    public interface IReportDbAppService<TEntity> : IAppService<TEntity>
    where TEntity : REntity
    {
        [RServiceInterceptorViewAttribute]
        void UseReportServer();

        [RServiceInterceptorViewAttribute]
        void UseReportServerHD();

        [RServiceInterceptorViewAttribute]
        void UseReportServerMTST();

        [RServiceInterceptorViewAttribute]
        void UseReportServerMTGC();

        [RServiceInterceptorViewAttribute]
        void UseReportServerOTTS();

        [RServiceInterceptorViewAttribute]
        void UseReportServerBox();
    }
}
