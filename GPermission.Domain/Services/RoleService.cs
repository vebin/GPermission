using ECommon.Components;
using GPermission.Common;
using GPermission.Common.Enums;
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
        private IRoleRepository _roleRepository;
        public RoleService(IRoleIndexRepository roleIndexRepository, IRoleRepository roleRepository)
        {
            _roleIndexRepository = roleIndexRepository;
            _roleRepository = roleRepository;
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

        /// <summary>检测角色是否启用
        /// </summary>
        public void IsEnabled(string roleId)
        {
            var role = _roleRepository.QueryRoles(new { RoleId = roleId });
            if (role.Count() > 0)
            {
                if (role.FirstOrDefault().IsEnabled == (int)IsEnabledEnum.Disabled)
                {
                    throw new ValidateException(string.Format("角色Id为:{0}的角色未启用",roleId));
                }
            }
            else
            {
                throw new NotExistException(string.Format("角色Id为:{0}的角色不存在",roleId));
            }
        }
    }
}
