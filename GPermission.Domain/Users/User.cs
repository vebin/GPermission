using ENode.Domain;
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

        }

        /// <summary>删除用户
        /// </summary>
        public void Change(int useFlag)
        {

        }



        #region Event Handle Methods
        //创建
        private void Handle(UserCreated evnt)
        {
            _id = evnt.AggregateRootId;
            _info = evnt.Info;
            _roles = new List<string>();
            _status = "";
            _useFlag = (int)UseFlag.Useable;
        }

        //删除
        private void Handle(UserChanged evnt)
        {
            _useFlag = evnt.UseFlag;
        }

        #endregion

    }
}
