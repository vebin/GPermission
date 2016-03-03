﻿using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Accounts
{
    /// <summary>移除应用系统事件
    /// </summary>
    [Serializable]
    public class AppSystemRemoved : DomainEvent<string>
    {
        public string AppSystemId { get; private set; }

        public AppSystemRemoved()
        {

        }

        public AppSystemRemoved(Account account, string appSystemId) : base()
        {
            AppSystemId = appSystemId;
        }
    }
}