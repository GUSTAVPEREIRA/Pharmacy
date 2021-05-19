using Pharmacy.DTO.Users;

namespace Pharmacy.Services.IServices.Users
{
    public interface IUserService
    {
        public NewUserDTO CreateUser(NewUserDTO userDTO);
        public NewUserDTO GetUserByUsernameAndPassword(string username, string password);
    }
}