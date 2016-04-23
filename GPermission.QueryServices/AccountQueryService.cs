using System.Collections.Generic;
using ECommon.Dapper;
using GPermission.Common;
using GPermission.Common.Enums;
using GPermission.IQueryServices;
using System.Linq;
using GPermission.IQueryServices.Dtos;

namespace GPermission.QueryServices
{
    /// <summary>登录账号相关查询
    /// </summary>
    public class AccountQueryService : BaseQueryService, IAccountQueryService
    {
        /// <summary>根据账号Id查询账号信息
        /// </summary>
        public AccountInfo FindById(string accountId)
        {
            using (var connection = GetConnection())
            {
                var data = connection.QueryList<AccountInfo>(new
                {
                    AccountId = accountId,
                    UseFlag = (int) UseFlag.Useable
                }, ConfigSettings.AccountTable).FirstOrDefault();
                return data;
            }
        }

        /// <summary>根据账号名查询账号
        /// </summary>
        public AccountInfo FindByName(string accountName)
        {
            using (var connection = GetConnection())
            {
                var data = connection.QueryList<AccountInfo>(new
                {
                    AccountName = accountName,
                    UseFlag = (int) UseFlag.Useable
                }, ConfigSettings.AccountTable).FirstOrDefault();
                return data;
            }
        }

        /// <summary>查询全部账号
        /// </summary>
        public IEnumerable<AccountInfo> QueryAll()
        {
            using (var connction=GetConnection())
            {
                return connction.QueryList<AccountInfo>(new
                {
                    UseFlag = (int) UseFlag.Useable
                }, ConfigSettings.AccountTable);
            }
        }


    }
}
