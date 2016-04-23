using ENode.Commanding;

namespace GPermission.Commands.AppSystems
{
    /// <summary>更新应用信息
    /// </summary>
    public class UpdateAppSystem:Command<string>
    {
        public string Name { get; set; }
        public string ReMark { get; set; }

        public UpdateAppSystem()
        {
            
        }

        public UpdateAppSystem(string id, string name, string reMark = "") : base(id)
        {
            Name = name;
            ReMark = reMark;
        }
    }
}
