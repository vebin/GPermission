using ECommon.Components;
using GPermission.Common;
using GPermission.Domain.AppSystems;
using GPermission.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Services
{
    /// <summary>应用系统领域服务
    /// </summary>
    [Component]
    public class AppSystemService
    {
        private IAppSystemIndexRepository _appSystemIndexRepository;
        public AppSystemService(IAppSystemIndexRepository appSystemIndexRepository)
        {
            _appSystemIndexRepository = appSystemIndexRepository;
        }

        /// <summary>注册应用系统代码索引
        /// </summary>
        public void RegisterAppSystemCodeIndex(string appSystemId, string code)
        {
            var codeIndex = _appSystemIndexRepository.FindByCode(code);
            if (codeIndex == null)
            {
                _appSystemIndexRepository.Add(new AppSystemCodeIndex(appSystemId, code));
            }
            else
            {
                throw new RepeatException("该系统代码已经存在");
            }
        }

        /// <summary>删除应用系统代码索引
        /// </summary>
        public void DeleteAppSystemCodeIndex(string appSystemId, string code = "")
        {
            _appSystemIndexRepository.Delete(new AppSystemCodeIndex(appSystemId, code));
        }

        /// <summary>是否存在检测
        /// </summary>
        public void Exist(string appSystemId)
        {
            var data = _appSystemIndexRepository.FindById(appSystemId);
            if (data == null)
            {
                throw new NotExistException("应用系统不存在");
            }
        }
    }
}
