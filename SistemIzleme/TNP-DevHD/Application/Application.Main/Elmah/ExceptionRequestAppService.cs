using Application.Main.Interfaces;
using Data.Main;
using Domain.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Main
{
    public class ExceptionRequestAppService : ElmahDbAppService<ExceptionRequest>, IExceptionRequestAppService
    {
        #region Constructor
        public ExceptionRequestAppService(IElmahDbRepository<ExceptionRequest> pRep)
            : base(pRep)
        {
        }
        #endregion

    }
}
