using Pharmacy.DTO.Users;

namespace Pharmacy.Services.IServices.Users
{
    public interface IUserService
    {
        public UserDTO CreateUser(NewUserDTO userDTO);
        public UserDTO GetUserByUsernameAndPassword(string username, string password);
    }
}