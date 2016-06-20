namespace GPermission.Domain.Repositories
{
    public interface IAccountRepository
    {
        /// <summary>根据Id查询账号信息
        /// </summary>
        Dtos.AccountInfo FindById(string accountId);
    }
}
