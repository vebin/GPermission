using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Common.Enums
{
    /// <summary>当前数据状态枚举
    /// </summary>
    public enum UseFlag
    {
        /// <summary>
        /// 使用中
        /// </summary>
        Useable = 1,
        /// <summary>
        /// 停用
        /// </summary>
        Disabled = 2,
        /// <summary>
        /// 取消
        /// </summary>
        Cancle = 4,
        /// <summary>
        /// 弃置
        /// </summary>
        Discard = 8
    }
}
