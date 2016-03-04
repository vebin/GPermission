using ENode.Domain;
using GPermission.Common;
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
       
        private int _isEnabled;
        private int _useFlag;

        public Role(string id, RoleInfo info, int isEnabled) : base(id)
        {
            Assert.IsNotNullOrEmpty("角色名称", info.Name);
            Assert.IsNotNullOrEmpty("角色代码", info.Code);
            Assert.IsNotInEnum("启用标志", typeof(IsEnabledEnum), isEnabled);
            ApplyEvent(new RoleCreated(this, info, isEnabled));
        }

        public void Change(int useFlag)
        {
            Assert.IsNotInEnum("删除标志", typeof(UseFlag), useFlag);
            ApplyEvent(new RoleChanged(this, useFlag));
        }


        #region Event Handle Methods
   
        private void Handle(RoleCreated evnt)
        {
            _id = evnt.AggregateRootId;
            _info = evnt.Info;
            _isEnabled = evnt.IsEnabled;
            _useFlag = (int)UseFlag.Useable;
        }

        private void Handle(RoleChanged evnt)
        {
            _useFlag = evnt.UseFlag;
        }

        #endregion

    }
}
