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
        public void AddUserRole(List<string> roleIds)
        {
            foreach (var roleId in roleIds)
            {
                if (_roles.Contains(roleId))
                {
                    throw new RepeatException("该角色已经存在");
                }
            }
            ApplyEvent(new UserRoleAdded(this, roleIds));
        }

        /// <summary>删除用户角色
        /// </summary>
        public void RemoveUserRole(string roleId)
        {
            var id = _roles.Where(x => x == roleId).FirstOrDefault();
            if (string.IsNullOrEmpty(id))
            {
                throw new NotExistException("该用户的权限不存在");
            }
            ApplyEvent(new UserRoleRemoved(this, roleId));
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

        private void Handle(UserRoleAdded evnt)
        {
            foreach (var roleId in evnt.RoleIds)
            {
                _roles.Add(roleId);
            }
        }

        private void Handle(UserRoleRemoved evnt)
        {
            _roles.Remove(evnt.RoleId);
        }

        private void Handle(UserChanged evnt)
        {
            _useFlag = evnt.UseFlag;
        }

        #endregion

    }
}
