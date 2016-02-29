using GPermission.Domain.AppSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Repositories
{
    /// <summary>应用系统仓储
    /// </summary>
    public interface IAppSystemIndexRepository
    {
        /// <summary>根据应用系统代码查询索引
        /// </summary>
        AppSystemCodeIndex FindByCode(string code);

        /// <summary>创建系统应用代码索引
        /// </summary>
        void Add(AppSystemCodeIndex index);

        /// <summary>删除系统应用代码索引
        /// </summary>
        void Delete(AppSystemCodeIndex index);

        /// <summary>根据Id查询应用系统
        /// </summary>
        dynamic GetById(string appSystemId);
    }
}
