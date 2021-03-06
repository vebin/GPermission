﻿using System.Collections.Generic;
using GPermission.IQueryServices.DTOs;

namespace GPermission.IQueryServices
{
    /// <summary>角色查询相关接口
    /// </summary>
    public interface IRoleQueryService
    {
        /// <summary>根据角色Id查询角色信息
        /// </summary>
        RoleInfo FindById(string roleId);

        /// <summary>根据系统Id,角色代码查询角色信息
        /// </summary>
        RoleInfo FindByCode(string appSystemId, string code);

        /// <summary>根据系统Id查询所有的角色
        /// </summary>
        IEnumerable<RoleInfo> FindAll(string appSystemId);
        
        /// <summary>根据用户Id,查询用户所拥有的角色
        /// </summary>
        IEnumerable<RoleInfo> FindUserRole(string userId);
    }
}
