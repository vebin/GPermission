using ECommon.Components;
using GPermission.Common;
using GPermission.Domain.Repositories;
using GPermission.Domain.Users;
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
            var codeIndex = _userIndexRepository.FindByCode(code);
            if (codeIndex == null)
            {
                _userIndexRepository.Add(new UserCodeIndex(userId, code));
            }
            else
            {
                throw new RepeatException("");
            }
        }

        /// <summary>删除用户代码索引
        /// </summary>
        public void DeleteUserCodeIndex(string userId, string code = "")
        {
            _userIndexRepository.Delete(new UserCodeIndex(userId, code));
        }
    }
}
