using System.Linq;
using ECommon.Components;
using ECommon.Dapper;
using GPermission.Common;
using GPermission.Common.Enums;
using GPermission.Domain.Repositories;

namespace GPermission.Repositories.Dapper
{
    [Component]
    public class AppSystemRepository:BaseRepository,IAppSystemRepository
    {
        /// <summary>根据Id查询应用信息
        /// </summary>
        public Domain.Repositories.Dtos.AppSystemInfo FindById(string appSystemId)
        {
            using (var connection=GetConnection())
            {
                return connection.QueryList<Domain.Repositories.Dtos.AppSystemInfo>(new
                {
                    AppSystemId = appSystemId,
                    UseFlag = (int) UseFlag.Useable
                }, ConfigSettings.AppSystemTable).FirstOrDefault();
            }
        }
    }
}
