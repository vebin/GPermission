using ECommon.Components;
using GPermission.Common;
using GPermission.Domain.Repositories;
using GPermission.Domain.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Services
{
    /// <summary>角色领域服务
    /// </summary>
    [Component]
    public  class RoleService
    {
        private IRoleIndexRepository _roleIndexRepository;
        public RoleService(IRoleIndexRepository roleIndexRepository)
        {
            _roleIndexRepository = roleIndexRepository;
        }

        /// <summary>注册角色代码索引
        /// </summary>
        public void RegisterRoleCodeIndex(string roleId, string code)
        {
            var codeIndex = _roleIndexRepository.FindByCode(code);
            if (codeIndex == null)
            {
                _roleIndexRepository.Add(new RoleCodeIndex(roleId, code));
            }
            else
            {
                throw new RepeatException("该角色代码已经存在");
            }
        }

        /// <summary>删除角色代码索引
        /// </summary>
        public void DeleteRoleCodeIndex(string roleId, string code = "")
        {
            _roleIndexRepository.Delete(new RoleCodeIndex(roleId, code));
        }
    }
}
