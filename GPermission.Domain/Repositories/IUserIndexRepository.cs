using GPermission.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Repositories
{
    /// <summary>用户领域仓储
    /// </summary>
    public interface IUserIndexRepository
    {
        /// <summary>根据代码查询用户索引
        /// </summary>
        UserCodeIndex FindByCode(string code);

        /// <summary>创建用户代码索引
        /// </summary>
        void Add(UserCodeIndex index);

        /// <summary>删除用户代码索引
        /// </summary>
        void Delete(UserCodeIndex index);
    }
}
