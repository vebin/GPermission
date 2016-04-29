using ENode.Commanding;

namespace GPermission.Commands.Roles
{
    /// <summary>删除角色命令
    /// </summary>
    public class ChangeRole : Command<string>
    {
        public int UseFlag { get; set; }

        public ChangeRole()
        {

        }

        public ChangeRole(string id, int useFlag) : base(id)
        {
            UseFlag = useFlag;
        }
    }
}
