using CRM_Service.Entitys;
using CRM_Service.Models;
using CRM_Service.Services.IManagers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CRM_API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IGeneralManager<UserModel, UserInsertModel> generalManager;
        private IUserManager userManager;

        public UserController([FromKeyedServices("userServices")]IGeneralManager<UserModel, UserInsertModel> generalManager, IUserManager userManager)
        {
            this.generalManager = generalManager;
            this.userManager = userManager;

        }

        [Authorize]
        [HttpPost("create")]
        public async Task<ActionResult<Response>> CreateUser(UserInsertModel value)
        {
            var res = new Response();
            try
            {
                if (string.IsNullOrEmpty(value.Email) || string.IsNullOrEmpty(value.Phone))
                {
                    res.Message = $"Email o número de teléfono no pueden estar vacíos.";
                }
                else
                {
                    var emailValidationResult = await userManager.ValidateUserEmail(value.Email);
                    var UserValidationName = await userManager.ValidateUsername(value.Phone);
                    var phoneValidationResult = await userManager.ValidateUserPhone(value.Phone);

                    if (string.IsNullOrEmpty(emailValidationResult.Message) && string.IsNullOrEmpty(phoneValidationResult.Message) && string.IsNullOrEmpty(UserValidationName.Message))
                    {
                        res = await generalManager.Create(value);
                    }
                    else
                    {
                        var errorMessage = string.Join("; ", emailValidationResult.Message, phoneValidationResult.Message, UserValidationName.Message);
                        res.Message = errorMessage;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra durante el proceso
                res.Code = ex.HResult;
                res.Message = $"Error al crear usuario: {ex.Message}";
            }
            return Ok(res);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserModel>> Login(UserLoginModel value)
        {
            UserModel us = null;
            try
            {
                us = await userManager.Login(value);
            }catch (Exception ex)
            {
                return BadRequest("Error durante el inicio de sesión: " + ex.Message);
            }
            return us;
        }

        [Authorize]
        [HttpDelete("Delete")]
        public async Task<ActionResult<Response>> Delete(Int64 Id)
        {
            var res = new Response();
            try
            {
                res = await generalManager.Delete(Id);
            }
            catch (Exception ex)
            {
                res.Code = ex.HResult;
                res.Message = $"Error al crear usuario: {ex.Message}";
            }
            return Ok(res);
        }

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GetUsersModel>>> GetAll()
        {
            IEnumerable<GetUsersModel> Users = new List<GetUsersModel>(); // Cambia List<T> a IEnumerable<T>
            try
            {
                Users = await userManager.GetUsers();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(Users);
        }
    }
}
