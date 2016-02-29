using ECommon.Components;
using GPermission.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Services
{
    /// <summary>用户领域服务
    /// </summary>
    [Component]
    public class UserService
    {
        private  IUserIndexRepository _userIndexRepository;
        public UserService(IUserIndexRepository userIndexRepository)
        {
            _userIndexRepository = userIndexRepository;
        }

        /// <summary>注册用户代码索引
        /// </summary>
        public void RegisterUserCodeIndex(string userId, string code)
        {
           
        }
    }
}
