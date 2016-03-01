using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Repositories
{
    /// <summary>角色领域仓储
    /// </summary>
    public interface IRoleRepository
    {
        /// <summary>根据条件查询角色
        /// </summary>
        IEnumerable<dynamic> QueryRoles(object condition);
    }
}
