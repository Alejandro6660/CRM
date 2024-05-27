using CRM_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Service.Services.IManagers
{
    public interface IUserManager
    {
        Task<CRM_Service.Entitys.Response> CreateRol(RolUserInsertModel value);
        Task<CRM_Service.Entitys.Response> ValidateUserEmail (string email);
        Task<CRM_Service.Entitys.Response> ValidateUserPhone(string phone);
         Task<UserModel>Login(UserLoginModel login);
    }
}
