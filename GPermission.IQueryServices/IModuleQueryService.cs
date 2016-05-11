using System.Collections.Generic;
using GPermission.IQueryServices.DTOs;

namespace GPermission.IQueryServices
{
    /// <summary>模块相关查询接口
    /// </summary>
    public interface IModuleQueryService
    {
        /// <summary>根据模块Id查询模块
        /// </summary>
        ModuleInfo FindById(string moduleId);

        /// <summary>根据系统Id和模块编号查询模块
        /// </summary>
        ModuleInfo FindByCode(string appSystemId, string code);

        /// <summary>查询某个模块类型的最高级模块
        /// </summary>
        IEnumerable<ModuleInfo> FindModuleTypeHighests(string appSystemId, string moduleType);

        /// <summary>查询最高级模块
        /// </summary>
        IEnumerable<ModuleInfo> FindHighests(string appSystemId);

        /// <summary>查询所有子模块
        /// </summary>
        IEnumerable<ModuleInfo> FindSons(string appSystemId, string parentModule);
    }
}
