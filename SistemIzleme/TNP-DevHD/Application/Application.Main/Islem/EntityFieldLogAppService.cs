﻿using Application.Main.Interfaces;
using Application.ViewModels.Islem;
using Data.Main;
using Domain.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Application.Main
{
    public class EntityFieldLogAppService : IslemDbAppService<EntityFieldLog>, IEntityFieldLogAppService
    {
        #region Constructor
        public EntityFieldLogAppService(IIslemDbRepository<EntityFieldLog> pRep)
            : base(pRep)
        {
        }
        #endregion
    }
}
