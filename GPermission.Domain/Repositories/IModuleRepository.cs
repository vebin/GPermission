using GPermission.Domain.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Repositories
{
    /// <summary>模块领域仓储
    /// </summary>
    public interface IModuleRepository
    {
        /// <summary>根据模块Id查询模块信息
        /// </summary>
        dynamic FindById(string moduleId);
    }
}
