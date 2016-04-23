namespace GPermission.Domain.Repositories
{
    public interface IAppSystemRepository
    {
        /// <summary>根据Id查询应用信息
        /// </summary>
        Domain.Repositories.Dtos.AppSystemInfo FindById(string appSystemId);
    }
}
