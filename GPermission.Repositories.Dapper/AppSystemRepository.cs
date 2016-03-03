using ECommon.Components;
using ECommon.Dapper;
using GPermission.Common;
using GPermission.Domain.AppSystems;
using GPermission.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Repositories.Dapper
{
    /// <summary>应用系统领域仓储
    /// </summary>
    [Component]
    public class AppSystemRepository:BaseRepository, IAppSystemIndexRepository
    {
        /// <summary>根据应用系统代码查询索引
        /// </summary>
        public AppSystemCodeIndex FindByCode(string code)
        {
            using (var connection = GetConnection())
            {
                var data = connection.QueryList(new
                {
                    Code = code
                }, ConfigSettings.AppSystemCodeIndexTable).FirstOrDefault();

                if (data != null)
                {
                    return new AppSystemCodeIndex(data.AppSystemId,data.Code);
                }
                return null;
            }
        }

        /// <summary>创建系统应用代码索引
        /// </summary>
        public void Add(AppSystemCodeIndex index)
        {
            using (var connection = GetConnection())
            {
                connection.Insert(new
                {
                    AppSystemId=index.AppSystemId,
                    Code=index.Code
                },ConfigSettings.AppSystemCodeIndexTable);
            }
        }

        /// <summary>删除系统应用代码索引
        /// </summary>
        public void Delete(AppSystemCodeIndex index)
        {
            using (var connection = GetConnection())
            {
                connection.Delete(new
                {
                    AppSystemId=index.AppSystemId
                }, ConfigSettings.AppSystemCodeIndexTable);
            }
        }

        /// <summary>根据Id查询应用系统
        /// </summary>
        public dynamic FindById(string appSystemId)
        {
            using (var connection = GetConnection())
            {
                var data = connection.QueryList(new
                {
                    AppSystemId = appSystemId
                }, ConfigSettings.AppSystemTable).FirstOrDefault();
                return data;
            }
        }
    }
}
