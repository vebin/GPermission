using System;
using ECommon.Utilities;
using ENode.Commanding;

namespace GPermission.Commands.AppSystems
{
    /// <summary>创建系统应用
    /// </summary>
    public class CreateAppSystem:Command<string>
    {
        public string AccountId { get; set; }
        public string Name { get; set; }
        public string ReMark { get; set; }
        public string Code { get; set; }
        public string SafeKey { get; set; }
        public DateTime CreateTime { get; set; }


        public CreateAppSystem()
        {
            
        }

        public CreateAppSystem(string id,string accountId, string name, string reMark = "") : base(id)
        {
            AccountId = accountId;
            Code = ObjectId.GenerateNewStringId();
            Name = name;
            SafeKey = ObjectId.GenerateNewStringId();
            CreateTime = DateTime.Now;
            ReMark = reMark;
        }
    }
}
