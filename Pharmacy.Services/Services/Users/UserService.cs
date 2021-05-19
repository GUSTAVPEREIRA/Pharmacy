using AutoMapper;
using Pharmacy.Cryptographic;
using Pharmacy.DTO.Users;
using Pharmacy.Extensions.Exceptions;
using Pharmacy.Infra.Repositories.IRepositories.Users;
using Pharmacy.Model.Users;
using Pharmacy.Services.IServices.Users;
using System.Net;

namespace Pharmacy.Services.Services.Users
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public NewUserDTO CreateUser(NewUserDTO userDTO)
        {
            var user = _mapper.Map<NewUserDTO, User>(userDTO);

            if (_userRepository.VerifyIfUserExist(user.Username))
            {
                throw new APIException("Este username já está em uso!", HttpStatusCode.BadRequest);
            }

            _userRepository.Save(user);
            userDTO.Id = user.Id;
            userDTO.Password = "";

            return userDTO;
        }

        public NewUserDTO GetUserByUsernameAndPassword(string username, string password)
        {
            var result = _userRepository.GetUserByUsernameAndPassword(username);

            if (result == null)
            {
                throw new APIException("Senha ou Username inválido!", HttpStatusCode.NotFound);
            }

            var validPassowrd = new PBKDF2().Verify(password, result.Password);
            var userDTO = _mapper.Map<User, NewUserDTO>(result);

            if (!validPassowrd)
            {
                throw new APIException("Senha ou Username inválido!", HttpStatusCode.Unauthorized);
            }

            userDTO.Password = "";

            return userDTO;
        }
    }
}