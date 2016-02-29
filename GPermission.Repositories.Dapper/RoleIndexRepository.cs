using ECommon.Dapper;
using GPermission.Common;
using GPermission.Domain.Repositories;
using GPermission.Domain.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GPermission.Repositories.Dapper
{
    /// <summary>角色领域仓储
    /// </summary>
    public class RoleIndexRepository : BaseRepository, IRoleIndexRepository
    {
        /// <summary>根据代码查询角色索引
        /// </summary>
        public RoleCodeIndex FindByCode(string code)
        {
            using (var connection = GetConnection())
            {
                var data = connection.QueryList(new
                {
                    Code = code
                }, ConfigSettings.RoleCodeIndexTable).FirstOrDefault();

                if (data != null)
                {
                    return new RoleCodeIndex(data.RoleId, data.Code);
                }
                return null;
            }
        }

        /// <summary>创建角色代码索引
        /// </summary>
        public void Add(RoleCodeIndex index)
        {
            using (var connection = GetConnection())
            {
                connection.Insert(new
                {
                    RoleId=index.RoleId,
                    Code=index.Code
                }, ConfigSettings.RoleCodeIndexTable);
            }
        }

        /// <summary>删除角色代码索引
        /// </summary>
        public void Delete(RoleCodeIndex index)
        {
            using (var connection = GetConnection())
            {
                connection.Delete(new
                {
                    RoleId=index.RoleId
                }, ConfigSettings.RoleCodeIndexTable);
            }
        }
    }
}
