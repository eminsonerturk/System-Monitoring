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
    public class MessageLogAppService : IslemDbAppService<MessageLog>, IMessageLogAppService
    {
        #region Constructor
        public MessageLogAppService(IIslemDbRepository<MessageLog> pRep)
            : base(pRep)
        {
        }
        #endregion
    }
}
