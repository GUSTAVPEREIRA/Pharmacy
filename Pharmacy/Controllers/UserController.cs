using Microsoft.AspNetCore.Mvc;
using Pharmacy.DTO.Users;
using Pharmacy.Extensions.Exceptions;
using Pharmacy.Services.IServices.Users;

namespace Pharmacy.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Creating a new user
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [Route("create")]
        [HttpPost]
        public ActionResult<UserDTO> CreateUser(UserDTO userDTO)
        {
            try
            {
                var result = _userService.CreateUser(userDTO);

                return new OkObjectResult(new
                {
                    User = result,
                    Message = "Usuário criado com sucesso!"
                });
            }
            catch (APIException ex)
            {
                return new BadRequestObjectResult(new
                {
                    ex.Message,
                    Code = ex.StatusCode
                });
            }
        }
    }
}