using Pharmacy.Infra.Data;
using Pharmacy.Infra.Repositories.IRepositories.Users;
using Pharmacy.Model.Users;
using System.Linq;

namespace Pharmacy.Infra.Repositories.Repositories.Users
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
            Context = context;
        }

        public User GetUserByUsernameAndPassword(string username)
        {
            var result = Context.TbUsers
                .Where(w => w.Username == username).FirstOrDefault();

            return result;
        }

        public bool VerifyIfUserExist(string username)
        {
            var result = Context.TbUsers.Where(w => w.Username == username).Any();

            return result;
        }
    }
}
