using System.Linq;
using ECommon.Components;
using ECommon.Dapper;
using GPermission.Common;
using GPermission.Common.Enums;
using GPermission.Domain.Repositories;

namespace GPermission.Repositories.Dapper
{
    [Component]
    public class AccountRepository:BaseRepository,IAccountRepository
    {
        /// <summary>根据Id查询账号信息
        /// </summary>
        public Domain.Repositories.Dtos.AccountInfo FindById(string accountId)
        {
            using (var connection = GetConnection())
            {
                return connection.QueryList<Domain.Repositories.Dtos.AccountInfo>(new
                {
                    AccountId = accountId,
                    UseFlag = (int) UseFlag.Useable
                }, ConfigSettings.AccountTable).FirstOrDefault();
            }
        }
    }
}
