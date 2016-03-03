using ECommon.Components;
using ECommon.Dapper;
using GPermission.Common;
using GPermission.Common.Enums;
using GPermission.Domain.Modules;
using GPermission.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Repositories.Dapper
{
    /// <summary>模块领域仓储
    /// </summary>
    [Component]
    public class ModuleRepository:BaseRepository, IModuleRepository
    {
        /// <summary>根据模块Id查询模块信息
        /// </summary>
        public dynamic FindById(string moduleId)
        {
            using (var connection = GetConnection())
            {
                var data = connection.QueryList(new
                {
                    ModuleId = moduleId,
                    UseFlag = (int)UseFlag.Useable
                }, ConfigSettings.ModuleTable).FirstOrDefault();
                return data;
            }
        }
    }
}
