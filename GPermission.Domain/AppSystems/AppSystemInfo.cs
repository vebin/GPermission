using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.AppSystems
{
    /// <summary>应用系统信息实体
    /// </summary>
    [Serializable]
    public class AppSystemInfo
    {
        /// <summary>应用代码(唯一,不可变)
        /// </summary>
        public string Code { get; set; }
        /// <summary>应用名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        public AppSystemInfo()
        {

        }

        public AppSystemInfo(string code,string name)
        {

        }
    }
}
