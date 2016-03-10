using GPermission.IQueryServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.IQueryServices
{
    /// <summary>应用系统查询接口
    /// </summary>
    public interface IAppSystemQueryService
    {
        /// <summary>根据系统Id查询系统
        /// </summary>
        AppSystemInfo FindById(string appSystemId);

        /// <summary>根据应用系统编号查询系统
        /// </summary>
        AppSystemInfo FindByCode(string code);

        /// <summary>应用系统分页
        /// </summary>
        IEnumerable<AppSystemInfo> Paging(string code = "", string name = "", string status = "", string orderBy = "AppSystemId", int pageSize = 10, int pageIndex = 1);
    }
}
