using ENode.Domain;
using GPermission.Common;
using GPermission.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Permissions
{
    /// <summary>权限聚合根
    /// </summary>
    [Serializable]
    public class Permission : AggregateRoot<string>
    {
        private PermissionInfo _info;
        private int _isVisible;
        private string _status;
        private int _useFlag;

        /// <summary>创建权限
        /// </summary>
        public Permission(string id, PermissionInfo info,int isVisiable) : base(id)
        { 
            Assert.IsNotNullOrEmpty("权限名称", info.Name);
            Assert.IsNotNullOrEmpty("权限代码", info.Code);
            Assert.IsNotNullOrEmpty("权限类型", info.PermissionType);
            Assert.IsNotInEnum("可见类型", typeof(BoolEnum), isVisiable);
            ApplyEvent(new PermissionCreated(info, isVisiable));
        }

        /// <summary>更新权限
        /// </summary>
        public void Update(PermissionEditableInfo info)
        {
            if(_status==PermissionStatus.Locked.ToString())
            {
                throw new ValidateException("该权限处于锁定状态无法更新,请先解锁");
            }
            Assert.IsNotNullOrEmpty("权限名称", info.Name);
            Assert.IsNotNullOrEmpty("权限类型", info.PermissionType);
            ApplyEvent(new PermissionUpdated(info));
        }

        /// <summary>设置为可见
        /// </summary>
        public void SetVisible()
        {
            if (_isVisible == (int)BoolEnum.True)
            {
                throw new ValidateException("该权限已经处于可见状态");
            }
            ApplyEvent(new PermissionVisibled());
        }


        /// <summary>设置为隐藏
        /// </summary>
        public void SetInVisible()
        {
            if (_isVisible == (int)BoolEnum.False)
            {
                throw new ValidateException("该权限已经处于隐藏状态");
            }
            ApplyEvent(new PermissionInVisibled());
        }

        /// <summary>锁定权限
        /// </summary>
        public void Locked()
        {
            if (_status == PermissionStatus.Locked.ToString())
            {
                throw new ValidateException("该权限已经处于锁定状态");
            }
            ApplyEvent(new PermissionLocked());
        }

        /// <summary>解锁权限
        /// </summary>
        public void UnLock()
        {
            if (_status == PermissionStatus.Normal.ToString())
            {
                throw new ValidateException("该权限已经处于解锁状态");
            }
            ApplyEvent(new PermissionUnLock());
        }


        /// <summary>删除权限
        /// </summary>
        public void Change(int useFlag)
        {
            Assert.IsNotInEnum("删除标志", typeof (UseFlag), useFlag);
            ApplyEvent(new PermissionChanged(useFlag));
        }


        #region Event Handle Methods
        private void Handle(PermissionCreated evnt)
        {
            _id = evnt.AggregateRootId;
            _info = evnt.Info;
            _isVisible = evnt.IsVisible;
            _status = PermissionStatus.Normal.ToString();
            _useFlag = (int)UseFlag.Useable;
        }

        private void Handle(PermissionUpdated evnt)
        {
            var editableInfo = evnt.Info;
            _info = new PermissionInfo(_info.AppSystemId,
                _info.Code,
                editableInfo.Name,
                editableInfo.PermissionType,
                editableInfo.ParentPermission,
                editableInfo.PermissionUrl,
                editableInfo.Sort,
                editableInfo.ReMark);
        }

        private void Handle(PermissionVisibled evnt)
        {
            _isVisible = (int)BoolEnum.True;
        }

        private void Handle(PermissionInVisibled evnt)
        {
            _isVisible = (int)BoolEnum.False;
        }

        private void Handle(PermissionLocked evnt)
        {
            _status = PermissionStatus.Locked.ToString();
        }

        private void Handle(PermissionUnLock evnt)
        {
            _status = PermissionStatus.Normal.ToString();
        }

        
        private void Handle(PermissionChanged evnt)
        {
            _useFlag = evnt.UseFlag;
        }

        #endregion
    }
}
