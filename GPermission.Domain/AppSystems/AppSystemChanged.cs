using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.AppSystems
{
    /// <summary>删除应用系统事件
    /// </summary>
    [Serializable]
    public class AppSystemChanged : DomainEvent<string>
    {
        public int UseFlag { get; private set; }

        public AppSystemChanged()
        {

        }

        public AppSystemChanged(AppSystem appSystem,int useFlag) : base()
        {
            UseFlag = useFlag;
        }
    }
}
