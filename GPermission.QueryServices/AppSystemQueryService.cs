using ECommon.Dapper;
using GPermission.Common;
using GPermission.Common.Enums;
using GPermission.IQueryServices;
using System.Collections.Generic;
using System.Linq;
using GPermission.IQueryServices.Dtos;

namespace GPermission.QueryServices
{
    /// <summary>应用系统查询
    /// </summary>
    public class AppSystemQueryService : BaseQueryService, IAppSystemQueryService
    {
        /// <summary>根据系统Id查询系统
        /// </summary>
        public AppSystemInfo FindById(string appSystemId)
        {
            using (var connection = GetConnection())
            {
                return connection.QueryList<AppSystemInfo>(new
                {
                    AppSystemId=appSystemId,
                    UseFlag=(int)UseFlag.Useable
                }, ConfigSettings.AppSystemTable).FirstOrDefault();
            }
        }

        /// <summary>根据应用系统编号查询系统
        /// </summary>
        public AppSystemInfo FindByCode(string code)
        {
            using (var connection = GetConnection())
            {
                return connection.QueryList<AppSystemInfo>(new
                {
                    Code = code,
                    UseFlag = (int) UseFlag.Useable
                }, ConfigSettings.AppSystemTable).FirstOrDefault();
            }
        }



        /// <summary>应用系统分页
        /// </summary>
        public IEnumerable<AppSystemInfo> Paging(string code="",string name="",string status="",string orderBy="AppSystemId", int pageSize = 10, int pageIndex = 1)
        {
            dynamic condition = new
            {
                UseFlag=(int)UseFlag.Useable
            };
            if (!string.IsNullOrEmpty(code))
            {
                condition.Code = code;
            }
            if (!string.IsNullOrEmpty(name))
            {
                condition.Name = name;
            }
            if (!string.IsNullOrEmpty(status))
            {
                condition.Status = status;
            }

            using (var connection = GetConnection())
            {
                return connection.QueryPaged<AppSystemInfo>(condition as object, ConfigSettings.AppSystemTable, orderBy, pageIndex, pageSize);
            }
        }
    }
}
