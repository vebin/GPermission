using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.AppSystems
{
    /// <summary>应用系统代码索引
    /// </summary>
    public class AppSystemCodeIndex
    {
        public string AppSystemId { get; set; }

        public string Code { get; set; }
        public AppSystemCodeIndex(string appSystemId, string code)
        {
            AppSystemId = appSystemId;
            Code = code;
        }
    }
}
