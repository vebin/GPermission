using ENode.Commanding;

namespace GPermission.Commands.Roles
{
    /// <summary>更新角色
    /// </summary>
    public class UpdateRole : Command<string>
    {
        public string Name { get; set; }
        public string RoleType { get; set; }
        public int IsEnabled { get; set; }
        public string ReMark { get; set; }

        public UpdateRole()
        {
            
        }

        public UpdateRole(string id, string name, string roleType, int isEnabled, string reMark = "") : base(id)
        {
            Name = name;
            RoleType = roleType;
            IsEnabled = isEnabled;
            ReMark = reMark;
        }
    }
}
