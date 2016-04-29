using System.Collections.Generic;
using GPermission.IQueryServices.DTOs;

namespace GPermission.IQueryServices
{
    /// <summary>用户查询接口
    /// </summary>
    public interface IUserQueryService
    {
        /// <summary>根据用户Id查询用户账号
        /// </summary>
        UserInfo FindById(string userId);

        /// <summary>根据用户代码查询用户
        /// </summary>
        UserInfo FindByCode(string appSystemId,string code);

        /// <summary>查询某个系统下所有用户
        /// </summary>
        IEnumerable<UserInfo> FindAllByAppSystemId(string appSystemId);
    }
}
