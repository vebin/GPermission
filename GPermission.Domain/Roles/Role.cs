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
        private List<string> _modulePermissions;
        private int _isEnabled;
        private int _useFlag;

        /// <summary>创建角色
        /// </summary>
        public Role(string id, RoleInfo info, int isEnabled) : base(id)
        {
            Assert.IsNotNullOrEmpty("角色名称", info.Name);
            Assert.IsNotNullOrEmpty("角色代码", info.Code);
            Assert.IsNotInEnum("启用标志", typeof(IsEnabledEnum), isEnabled);
            ApplyEvent(new RoleCreated(this, info, isEnabled));
        }

        /// <summary>删除角色
        /// </summary>
        public void Change(int useFlag)
        {
            Assert.IsNotInEnum("删除标志", typeof(UseFlag), useFlag);
            ApplyEvent(new RoleChanged(this, useFlag));
        }

        /// <summary>添加角色模块权限
        /// </summary>
        public void AttachModulePermission(List<string> modulePermissionIds)
        {
            foreach (var modulePermissionId in modulePermissionIds)
            {
                if (_modulePermissions.Contains(modulePermissionId))
                {
                    throw new RepeatException("该角色已经存在");
                }
            }
            ApplyEvent(new RoleModulePermissionAttached(this, modulePermissionIds));
        }

        /// <summary>删除角色模块权限
        /// </summary>
        public void DetachModulePermission(string modulePermissionId)
        {
            if (!_modulePermissions.Contains(modulePermissionId))
            {
                throw new NotExistException("该角色模块权限不存在");
            }
            ApplyEvent(new RoleModulePermissionDetached(this, modulePermissionId));
        }

        /// <summary>更新角色模块权限
        /// </summary>
        public void UpdateModulePermission(List<string> modulePermissionIds)
        {
            ApplyEvent(new RoleModulePermissionUpdated(this, modulePermissionIds));
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

        private void Handle(RoleModulePermissionAttached evnt)
        {
            foreach (var modulePermissionId in evnt.ModulePermissionIds)
            {
                _modulePermissions.Add(modulePermissionId);
            }
        }

        private void Handle(RoleModulePermissionDetached evnt)
        {
            _modulePermissions.Remove(evnt.ModulePermissionId);
        }

        private void Handle(RoleModulePermissionUpdated evnt)
        {
            _modulePermissions = evnt.ModulePermissionIds;
        }

        #endregion

    }
}
