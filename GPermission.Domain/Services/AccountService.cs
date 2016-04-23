using ECommon.Components;
using GPermission.Common;
using GPermission.Domain.Repositories;

namespace GPermission.Domain.Services
{
    /// <summary>账号领域服务
    /// </summary>
    [Component]
    public class AccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void CheckExist(string accountId)
        {
            var info = _accountRepository.FindById(accountId);
            if (info == null)
            {
                throw new NotExistException("账号不存在");
            }
        }

    }
}
