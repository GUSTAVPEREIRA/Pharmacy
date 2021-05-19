using Pharmacy.DTO.Users;

namespace Pharmacy.Services.IServices.Tokens
{
    public interface ITokenService
    {
        public string GenerateToken(NewUserDTO user);
    }
}