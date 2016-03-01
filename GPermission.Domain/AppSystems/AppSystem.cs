using ENode.Domain;
using GPermission.Common;
using GPermission.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.AppSystems
{
    /// <summary>应用系统聚合根
    /// </summary>
    [Serializable]
    public class AppSystem : AggregateRoot<string>
    {
        private AppSystemInfo _info;
        private string _safeKey;
        private string _status;
        private int _useFlag;

        /// <summary>创建应用系统
        /// </summary>
        public AppSystem(string id, AppSystemInfo info,string safeKey) : base(id)
        {
            Assert.IsNotNullOrEmpty("应用系统名称", info.Name);
            Assert.IsNotNullOrEmpty("应用系统代码", info.Code);
            ApplyEvent(new AppSystemCreated(this, info,safeKey));
        }

        /// <summary>删除应用系统
        /// </summary>
        public void Change(int useFlag)
        {
            Assert.IsNotInEnum("删除标志", typeof(UseFlag), useFlag);
            ApplyEvent(new AppSystemChanged(this, useFlag));
        }

        #region Event Handle Methods
        private void Handle(AppSystemCreated evnt)
        {
            _id = evnt.AggregateRootId;
            _info = evnt.Info;
            _safeKey = evnt.SafeKey;
            _status = "1";
            _useFlag = (int)UseFlag.Useable;
        }

        //删除
        private void Handle(AppSystemChanged evnt)
        {
            _useFlag = evnt.UseFlag;
        }

        #endregion
    }
}
