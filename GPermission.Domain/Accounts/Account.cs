using ENode.Domain;
using GPermission.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Accounts
{
    /// <summary>账号管理权限
    /// </summary>
    [Serializable]
    public class Account : AggregateRoot<string>
    {
        private AccountInfo _info;
        private string _status;
        private int _useFlag;

        #region Event Handle Methods
        private void Handle(AccountCreated evnt)
        {
            _id = evnt.AggregateRootId;
            _info = evnt.Info;
            _status = "1";
            _useFlag = (int)UseFlag.Useable;
        }

        //删除
        private void Handle(AccountChanged evnt)
        {
            _useFlag = evnt.UseFlag;
        }

        #endregion
    }
}
