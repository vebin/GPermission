using ECommon.Components;
using GPermission.Common;
using GPermission.Domain.Repositories;

namespace GPermission.Domain.Services
{
    /// <summary>应用系统领域服务
    /// </summary>
    [Component]
    public class AppSystemService
    {

        private readonly IAppSystemRepository _appSystemRepository;
        public AppSystemService(IAppSystemRepository appSystemRepository)
        {
            _appSystemRepository = appSystemRepository;
        }


        public void CheckExist(string appSystemId)
        {
            var info = _appSystemRepository.FindById(appSystemId);
            if (info == null)
            {
                throw new NotExistException("该应用不存在");
            }
        }

    }
}
