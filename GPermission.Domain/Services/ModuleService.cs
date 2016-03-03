using ECommon.Components;
using GPermission.Common;
using GPermission.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Services
{
    /// <summary>模块领域服务
    /// </summary>
    [Component]
    public class ModuleService
    {
        private IModuleRepository _moduleRepository;
        public ModuleService(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        /// <summary>模块不存在
        /// </summary>
        public void Exist(string moduleId)
        {
            var moduleDto = _moduleRepository.FindById(moduleId);
            if (moduleDto == null)
            {
                throw new NotExistException("模块不存在");
            }
        }


    }
}
