using CRM_Service.Entitys;
using CRM_Service.Models;
using CRM_Service.Services.IManagers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace CRM_API.Controllers
{
    [Route("api/roluser")]
    [ApiController]
    public class RolUserController : ControllerBase
    {
        //private IGeneralManager<RolUserModel> ServiceGeneral; 
        private IUserManager ServiceUser; 
        public RolUserController(/*IGeneralManager<RolUserModel> ServiceGeneral,*/ 
            IUserManager ServiceUser)
        { 
            //this.ServiceGeneral = ServiceGeneral;
            this.ServiceUser = ServiceUser;
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<ActionResult<Response>> Create(RolUserInsertModel value)
        {
            var res = new Response();
            try
            {
                res = await ServiceUser.CreateRol(value);
                if(res.Message == String.Empty || res.Message == null)
                {
                    res.Message = "Se guardo con Exito!";
                }
                else
                {
                    BadRequest(res.Message);
                }
            }catch (Exception ex)
            {
                res.Message = $"Error! {ex.Message}";
                res.Code = ex.GetHashCode();
            }
            return res;
        }

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<RolUserModel>>> GetAll()
        {
            IEnumerable<RolUserModel> roles = new List<RolUserModel>(); // Utiliza List<T> en lugar de IEnumerable<T>
            try
            {
                roles = await ServiceUser.GetRol();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(roles);
        }

    }
}
