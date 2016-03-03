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
        private string _status;
        private int _useFlag;

        public Module(string id, ModuleInfo info) : base(id)
        {
            Assert.IsNotNullOrEmpty("模块名称", info.Name);

            ApplyEvent(new ModuleCreated(this, info));
        }

        public void Update(ModuleEditableInfo info,string verifyType,int isVisiable)
        {
            Assert.IsNotInEnum("是否可见", typeof(BoolEnum),isVisiable);
            ApplyEvent(new ModuleUpdated(this, info,verifyType,isVisiable));
        }

        public void SetVisiable()
        {
            if (_isVisible == (int)BoolEnum.True)
            {
                throw new ValidateException("该模块已经处于显示状态");
            }
            ApplyEvent(new ModuleVisibled(this));
        }

        public void SetUnVisiable()
        {
            if(_isVisible==(int)BoolEnum.False)
            {
                throw new ValidateException("该模块已经处于隐藏状态");
            }
            ApplyEvent(new ModuleUnVisibled(this));
        }

        public void SetLeaf(int isLeaf)
        {
            Assert.IsNotInEnum("模块节点状态", typeof(BoolEnum), isLeaf);

        }


        public void Change(int useFlag)
        {
            if (_isLeaf == (int)BoolEnum.False)
            {
                throw new ValidateException("该模块下含有子模块");
            }
            Assert.IsNotInEnum("删除标志", typeof(UseFlag), useFlag);
            ApplyEvent(new ModuleChanged(this, useFlag));
        }




        #region Event Handle Methods
        private void Handle(ModuleCreated evnt)
        {
            _id = evnt.AggregateRootId;
            _info = evnt.Info;
            _status = "1";
            _useFlag = (int)UseFlag.Useable;
        }

        private void Handle(ModuleUpdated evnt)
        {
            var editableInfo = evnt.Info;
            _info = new ModuleInfo(_info.AppSystemId, _info.Code, editableInfo.ModuleType, editableInfo.ParentModule, editableInfo.LinkUrl, editableInfo.AssemblyName, editableInfo.FullName);
            _isVisible = evnt.IsVisiable;
            _verifyType = evnt.VerifyType;
        }

        //删除
        private void Handle(ModuleChanged evnt)
        {
            _useFlag = evnt.UseFlag;
        }

        #endregion
    }
}
