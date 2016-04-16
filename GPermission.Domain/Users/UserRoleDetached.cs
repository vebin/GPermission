using ENode.Eventing;

namespace GPermission.Domain.Users
{
    /// <summary>删除用户角色
    /// </summary>
    public class UserRoleDetached : DomainEvent<string>
    {
        public string RoleId { get; private set; }

        public UserRoleDetached()
        {
        }
        public UserRoleDetached(string roleId) 
        {
            RoleId = roleId;
        }
    }
}
