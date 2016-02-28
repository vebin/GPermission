using ENode.Domain;
using GPermission.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Roles
{
    /// <summary>角色聚合根
    /// </summary>
    [Serializable]
    public class Role : AggregateRoot<string>
    {
        private RoleInfo _info;
        private string _status;
        private int _useFlag;

        #region Event Handle Methods
        //创建
        private void Handle(RoleCreated evnt)
        {
            _id = evnt.AggregateRootId;
            _info = evnt.Info;
            _status = "";
            _useFlag = (int)UseFlag.Useable;
        }

        //删除
        private void Handle(RoleChanged evnt)
        {
            _useFlag = evnt.UseFlag;
        }

        #endregion

    }
}
