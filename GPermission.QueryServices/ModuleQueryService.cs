using ECommon.Dapper;
using GPermission.Common;
using GPermission.Common.Enums;
using GPermission.IQueryServices;
using System.Collections.Generic;
using System.Linq;
using GPermission.IQueryServices.DTOs;

namespace GPermission.QueryServices
{
    /// <summary>模块相关查询
    /// </summary>
    public class ModuleQueryService : BaseQueryService, IModuleQueryService
    {
        /// <summary>根据模块Id查询模块
        /// </summary>
        public ModuleInfo FindById(string moduleId)
        {
            using (var connection = GetConnection())
            {
                return connection.QueryList(new
                {
                    ModuleId=moduleId,
                    UseFlag=(int)UseFlag.Useable
                }, ConfigSettings.ModuleTable).FirstOrDefault();
            }
        }

        /// <summary>根据系统Id和模块编号查询模块
        /// </summary>
        public ModuleInfo FindByCode(string appSystemId, string code)
        {
            using (var connection = GetConnection())
            {
                return connection.QueryList(new
                {
                    AppSystemId=appSystemId,
                    Code = code,
                    UseFlag = (int)UseFlag.Useable
                }, ConfigSettings.ModuleTable).FirstOrDefault();
            }
        }

        /// <summary>查询某个模块类型的最高模块
        /// </summary>
        public IEnumerable<ModuleInfo> FindModuleTypeHighests(string appSystemId, string moduleType)
        {
            using (var connection = GetConnection())
            {
                return connection.QueryList<ModuleInfo>(new
                {
                    AppSystemId=appSystemId,
                    ModuleType=moduleType,
                    ParentModule="",
                    UseFlag=(int)UseFlag.Useable
                }, ConfigSettings.ModuleTable);
            }
        }

        /// <summary>查询某系统最高模块
        /// </summary>
        public IEnumerable<ModuleInfo> FindHighests(string appSystemId)
        {
            using (var connection = GetConnection())
            {
                return connection.QueryList<ModuleInfo>(new
                {
                    AppSystemId = appSystemId,
                    ParentModule = "",
                    UseFlag = (int) UseFlag.Useable
                }, ConfigSettings.ModuleTable);
            }
        }
         
        
        /// <summary>查询所有子模块
        /// </summary>
        public IEnumerable<ModuleInfo> FindSons(string appSystemId,string parentModule)
        {
            using (var connection = GetConnection())
            {
                return connection.QueryList<ModuleInfo>(new
                {
                    AppSystemId=appSystemId,
                    ParentModule=parentModule
                }, ConfigSettings.ModuleTable);
            }
        }

        
    }
}
