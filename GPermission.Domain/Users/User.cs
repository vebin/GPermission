using ENode.Domain;
using GPermission.Common;
using GPermission.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Users
{
    /// <summary>账号聚合根
    /// </summary>
    [Serializable]
    public class User : AggregateRoot<string>
    {
        private UserInfo _info;
        private IList<string> _roles;
        private string _status;
        private int _useFlag;

        /// <summary>创建一个用户
        /// </summary>
        public User(string id, UserInfo info) : base(id)
        {
            Assert.IsNotNullOrEmpty("用户代码", info.Code);
            Assert.IsNotNullOrEmpty("用户名称", info.UserName);
            ApplyEvent(new UserCreated(this, info));
        }

        /// <summary>添加用户角色
        /// </summary>
        public void AttachUserRole(List<string> roleIds)
        {
            if (_status == UserStatus.Locked.ToString())
            {
                throw new ValidateException("该账号已经被锁定,请先解锁账号");
            }
            foreach (var roleId in roleIds)
            {
                if (_roles.Contains(roleId))
                {
                    throw new RepeatException("该角色已经存在");
                }
            }
            ApplyEvent(new UserRoleAttached(this, roleIds));
        }

        /// <summary>删除用户角色
        /// </summary>
        public void DetachUserRole(string roleId)
        {
            var id = _roles.Where(x => x == roleId).FirstOrDefault();
            if (string.IsNullOrEmpty(id))
            {
                throw new NotExistException("该用户的权限不存在");
            }
            ApplyEvent(new UserRoleDetached(this, roleId));
        }

        /// <summary>重置用户角色
        /// </summary>
        public void ResetUserRole(List<string> roleIds)
        {
            ApplyEvent(new UserRoleReset(this, roleIds));
        }

        /// <summary>锁定用户
        /// </summary>
        public void Locked()
        {
            if (_status == UserStatus.Locked.ToString())
            {
                throw new ValidateException("该用户已经处于锁定状态");
            }
            ApplyEvent(new UserLocked(this));
        }

        /// <summary>解锁用户
        /// </summary>
        public void Unlock()
        {
            if (_status == UserStatus.Normal.ToString())
            {
                throw new ValidateException("该用户已经解锁");
            }
            ApplyEvent(new UserUnLock(this));
        }

        /// <summary>删除用户
        /// </summary>
        public void Change(int useFlag)
        {
            Assert.IsNotInEnum("删除标志", typeof(UseFlag), useFlag);
            ApplyEvent(new UserChanged(this, useFlag));
        }

        #region Event Handle Methods
        private void Handle(UserCreated evnt)
        {
            _id = evnt.AggregateRootId;
            _info = evnt.Info;
            _roles = new List<string>();
            _status = "";
            _useFlag = (int)UseFlag.Useable;
        }

        private void Handle(UserRoleAttached evnt)
        {
            foreach (var roleId in evnt.RoleIds)
            {
                _roles.Add(roleId);
            }
        }

        private void Handle(UserRoleDetached evnt)
        {
            _roles.Remove(evnt.RoleId);
        }

        private void Handle(UserRoleReset evnt)
        {
            _roles = evnt.RoleIds;
        }

        private void Handle(UserChanged evnt)
        {
            _useFlag = evnt.UseFlag;
        }

        #endregion

    }
}
