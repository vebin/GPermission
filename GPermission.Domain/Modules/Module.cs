using ENode.Domain;
using GPermission.Common;
using GPermission.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Modules
{
    /// <summary>模块聚合根
    /// </summary>
    [Serializable]
    public class Module : AggregateRoot<string>
    {
        private ModuleInfo _info;
        private string _verifyType;
        private int _isLeaf;
        private int _isVisible;
        private IList<string> _permissions;
        private string _status;
        private int _useFlag;

        /// <summary>创建模块
        /// </summary>
        public Module(string id, ModuleInfo info,string verifyType,int isVisible) : base(id)
        {
            Assert.IsNotNullOrEmpty("模块名称", info.Name);

            ApplyEvent(new ModuleCreated(this, info,verifyType,isVisible));
        }

        /// <summary>更新模块
        /// </summary>
        public void Update(ModuleEditableInfo info, string verifyType, int isVisiable)
        {
            if (_status == ModuleStatus.Locked.ToString())
            {
                throw new ValidateException("该模块处于锁定状态无法更新,请先解锁");
            }
            Assert.IsNotInEnum("是否可见", typeof(BoolEnum), isVisiable);
            ApplyEvent(new ModuleUpdated(this, info, verifyType, isVisiable));
        }

        /// <summary>设置模块为可见
        /// </summary>
        public void SetVisible()
        {
            if (_isVisible == (int)BoolEnum.True)
            {
                throw new ValidateException("该模块已经处于显示状态");
            }
            ApplyEvent(new ModuleVisibled(this));
        }

        /// <summary>设置模块为隐藏
        /// </summary>
        public void SetInVisible()
        {
            if (_isVisible == (int)BoolEnum.False)
            {
                throw new ValidateException("该模块已经处于隐藏状态");
            }
            ApplyEvent(new ModuleInVisibled(this));
        }

        /// <summary>锁定模块
        /// </summary>
        public void Locked()
        {
            if (_status == ModuleStatus.Locked.ToString())
            {
                throw new ValidateException("该模块已经处于锁定状态");
            }
            ApplyEvent(new ModuleLocked(this));
        }

        /// <summary>模块解锁
        /// </summary>
        public void UnLock()
        {
            if (_status == ModuleStatus.Normal.ToString())
            {
                throw new ValidateException("该模块已经处于解锁");
            }
            ApplyEvent(new ModuleUnLock(this));
        }

        /// <summary>设置模块是否为叶子节点
        /// </summary>
        public void SetLeaf(int isLeaf)
        {
            Assert.IsNotInEnum("模块节点状态", typeof(BoolEnum), isLeaf);
            ApplyEvent(new ModuleLeafSetted(this, isLeaf));
        }

        /// <summary>删除模块
        /// </summary>
        public void Change(int useFlag)
        {
            if (_isLeaf == (int)BoolEnum.False)
            {
                throw new ValidateException("该模块下含有子模块");
            }
            Assert.IsNotInEnum("删除标志", typeof(UseFlag), useFlag);
            ApplyEvent(new ModuleChanged(this, useFlag));
        }

        /// <summary>添加模块权限
        /// </summary>
        public void AttachPermission(List<string> permissionIds)
        {
            foreach (var permissionId in permissionIds)
            {
                if (_permissions.Contains(permissionId))
                {
                    throw new RepeatException("该模块已经添加该条权限");
                }
            }
            ApplyEvent(new ModulePermissionAttached(this, permissionIds));
        }

        /// <summary>更新模块权限
        /// </summary>
        public void UpdateAttachPermission(List<string> permissionIds)
        {
            ApplyEvent(new ModulePermissionUpdated(this, permissionIds));
        }

        /// <summary>移除模块权限
        /// </summary>
        public void DetachPermission(string permissionId)
        {
            if (!_permissions.Contains(permissionId))
            {
                throw new NotExistException("该模块下不存在此权限");
            }
            ApplyEvent(new ModulePermissionDetached(this, permissionId));
        }


        #region Event Handle Methods
        private void Handle(ModuleCreated evnt)
        {
            _id = evnt.AggregateRootId;
            _info = evnt.Info;
            _isLeaf = (int)BoolEnum.True;
            _isVisible = (int)BoolEnum.True;
            _permissions = new List<string>();
            _status = ModuleStatus.Normal.ToString();
            _useFlag = (int)UseFlag.Useable;
        }

        private void Handle(ModuleUpdated evnt)
        {
            var editableInfo = evnt.Info;
            _info = new ModuleInfo(_info.AppSystemId, _info.Code, editableInfo.Name, editableInfo.ModuleType, editableInfo.ParentModule, editableInfo.LinkUrl, editableInfo.AssemblyName, editableInfo.FullName,editableInfo.Sort,editableInfo.ReMark);
            _isVisible = evnt.IsVisiable;
            _verifyType = evnt.VerifyType;
        }

        private void Handle(ModuleVisibled evnt)
        {
            _isVisible = (int)BoolEnum.True;
        }

        private void Handle(ModuleInVisibled evnt)
        {
            _isVisible = (int)BoolEnum.False;
        }

        private void Handle(ModuleLocked evnt)
        {
            _status = ModuleStatus.Locked.ToString();
        }

        private void Handle(ModuleUnLock evnt)
        {
            _status = ModuleStatus.Normal.ToString();
        }

        private void Handle(ModuleLeafSetted evnt)
        {
            _isLeaf = evnt.IsLeaf;
        }

        private void Handle(ModuleChanged evnt)
        {
            _useFlag = evnt.UseFlag;
        }

        private void Handle(ModulePermissionAttached evnt)
        {
            foreach(var permissionId in evnt.PermissionIds)
            {
                _permissions.Add(permissionId);
            }
        }

        private void Handle(ModulePermissionDetached evnt)
        {
            _permissions.Remove(evnt.PermissionId);
        }

        private void Handle(ModulePermissionUpdated evnt)
        {
            _permissions = evnt.PermissionIds;
        }

        #endregion
    }
}
