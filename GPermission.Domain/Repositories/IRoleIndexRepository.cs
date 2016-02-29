using GPermission.Domain.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Repositories
{
    /// <summary>角色领域仓储
    /// </summary>
    public interface IRoleIndexRepository
    {
        /// <summary>根据代码和系统Id查询角色索引
        /// </summary>
        RoleCodeIndex FindByCode(string code);

        /// <summary>创建角色代码索引
        /// </summary>
        void Add(RoleCodeIndex index);

        /// <summary>删除角色代码索引
        /// </summary>
        void Delete(RoleCodeIndex index);
    }
}
