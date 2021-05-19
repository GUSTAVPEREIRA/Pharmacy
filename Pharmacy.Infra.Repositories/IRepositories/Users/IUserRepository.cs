using Pharmacy.Model.Users;

namespace Pharmacy.Infra.Repositories.IRepositories.Users
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserByUsernameAndPassword(string username);
        bool VerifyIfUserExist(string username);
    }
}