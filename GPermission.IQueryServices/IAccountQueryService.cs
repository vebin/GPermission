using System.Collections.Generic;
using GPermission.IQueryServices.DTOs;

namespace GPermission.IQueryServices
{
    /// <summary>登录账号相关查询
    /// </summary>
    public interface IAccountQueryService
    {
        /// <summary>根据账号Id查询账号信息
        /// </summary>
        AccountInfo FindById(string accountId);

        /// <summary>根据账号名查询账号
        /// </summary>
        AccountInfo FindByName(string accountName);

        /// <summary>查询全部账号
        /// </summary>
         IEnumerable<AccountInfo> QueryAll();
    }
}
