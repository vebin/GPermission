using System.Configuration;
using ENode.Domain;
using GPermission.Common;
using GPermission.Common.Enums;

namespace GPermission.Domain.AppSystems
{
    /// <summary>应用系统聚合根
    /// </summary>
    public class AppSystem : AggregateRoot<string>
    {
        private AppSystemInfo _info;
        private string _safeKey;
        private string _status;
        private int _useFlag;

        /// <summary>创建应用系统
        /// </summary>
        public AppSystem(string id, AppSystemInfo info, string safeKey) : base(id)
        {
            Assert.IsNotNullOrEmpty("应用系统名称", info.Name);
            Assert.IsNotNullOrEmpty("应用系统代码", info.Code);
            ApplyEvent(new AppSystemCreated(info, safeKey));
        }

        /// <summary>删除应用系统
        /// </summary>
        public void Change(int useFlag)
        {
            Assert.IsNotInEnum("删除标志", typeof (UseFlag), useFlag);
            ApplyEvent(new AppSystemChanged(useFlag));
        }

        /// <summary>生成新的安全密钥
        /// </summary>
        public void UpdateSafeKey(string safeKey)
        {
            Assert.IsNotNullOrEmpty("安全密钥",safeKey);
            ApplyEvent(new SafeKeyUpdated(safeKey));
        }

        /// <summary>更新信息
        /// </summary>
        public void Update(AppSystemEditableInfo info)
        {
            Assert.IsNotNullOrEmpty("应用系统名称", info.Name);
            ApplyEvent(new AppSystemUpdated(info));
        }


        #region Event Handle Methods
        private void Handle(AppSystemCreated evnt)
        {
            _id = evnt.AggregateRootId;
            _info = evnt.Info;
            _safeKey = evnt.SafeKey;
            _status = AppSystemStatus.Normal.ToString();
            _useFlag = (int)UseFlag.Useable;
        }

        private void Handle(AppSystemChanged evnt)
        {
            _useFlag = evnt.UseFlag;
        }

        private void Handle(SafeKeyUpdated evnt)
        {
            _safeKey = evnt.SafeKey;
        }

        private void Handle(AppSystemUpdated evnt)
        {
            var editableInfo = evnt.Info;
            _info = new AppSystemInfo(_info.Code, editableInfo.Name, _info.AccountId, editableInfo.ReMark)
            {
                CreateTime = _info.CreateTime
            };
        }

        #endregion
    }
}
