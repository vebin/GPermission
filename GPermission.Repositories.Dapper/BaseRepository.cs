using GPermission.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GPermission.Repositories.Dapper
{
    public class BaseRepository
    {
        protected virtual IDbConnection GetConnection()
        {
            return new SqlConnection(ConfigSettings.GPermissionConnectionString);
        }
    }
}
