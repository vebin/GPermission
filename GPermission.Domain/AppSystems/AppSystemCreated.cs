using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.AppSystems
{
    /// <summary>创建应用系统事件
    /// </summary>
    [Serializable]
    public class AppSystemCreated : DomainEvent<string>
    {
        public AppSystemInfo Info { get; private set; }

        public AppSystemCreated()
        {

        }

        public AppSystemCreated(AppSystem appSystem,AppSystemInfo info) : base()
        {
            Info = info;
        }
    }
}
