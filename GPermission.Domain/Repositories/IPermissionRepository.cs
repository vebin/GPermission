using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Repositories
{
    /// <summary>权限领域仓储
    /// </summary>
    public interface IPermissionRepository
    {

        /// <summary>根据权限Id查询权限
        /// </summary>
        dynamic FindById(string permissionId);
    }
}
