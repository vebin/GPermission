using ENode.Eventing;

namespace GPermission.Domain.Roles
{
    /// <summary>更新角色
    /// </summary>
    public class RoleUpdated : DomainEvent<string>
    {
        public RoleEditableInfo Info { get; private set; }
        public int IsEnabled { get; private set; }

        public RoleUpdated()
        {
            
        }

        public RoleUpdated(RoleEditableInfo info, int isEnabled)
        {
            Info = info;
            IsEnabled = isEnabled;
        }
    }
}
