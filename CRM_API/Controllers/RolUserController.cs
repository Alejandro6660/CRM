using CRM_Service.Entitys;
using CRM_Service.Models;
using CRM_Service.Services.IManagers;
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
    }
}
