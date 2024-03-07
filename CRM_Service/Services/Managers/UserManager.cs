using CRM_Service.Context;
using CRM_Service.Entitys;
using CRM_Service.Enums;
using CRM_Service.Models;
using CRM_Service.Services.IManagers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Service.Services.Managers
{
    public class UserManager : IUserManager, IGeneralManager<UserModel, UserInsertModel>
    {
        private CRMContext context;
        private ISecurityBasic securityBasic;
        public UserManager(CRMContext context, ISecurityBasic securityBasic)
        {
            this.context = context;
            this.securityBasic = securityBasic;
        }

        public async Task<Response> Create(UserInsertModel poco)
        {
            var res = new Response();
            User user = new User();
            user.Name = poco.Name;
            user.Email = poco.Email;
            if (poco.RolUserId == 1)
            {
                if (string.IsNullOrEmpty(poco.Password))
                {
                    res.Message = "Error: La contraseña es requerida";
                    return res;
                }
                else
                {
                    // Cifrar la contraseña
                    string encryptedPassword = await securityBasic.Encrypt(poco.Password);
                    user.Password = encryptedPassword;
                }
            }
            user.Phone = poco.Phone;
            user.Addres = poco.Addres;
            user.RolUserId = poco.RolUserId;
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return res;
        }

        public async Task<Response> ValidateUserEmail(string email)
        {
            var res = new Response();
            var user = await context.Users.FirstOrDefaultAsync(p => p.Email == email);

            if (user != null)
            {
                res.Message = "User with this email already exists.";
                return res;
            }
            return res;
        }
        public async Task<Response> ValidateUserPhone(string phone)
        {
            var res = new Response();
            var user = await context.Users.FirstOrDefaultAsync(p => p.Phone == phone);

            if (user != null)
            {
                res.Message = "User with this phone already exists.";
                return res;
            }
            return res;
        }

        public async Task<Response> CreateRol(RolUserInsertModel value)
        {
            var res = new Response();
            RolUser rol = new RolUser();
            if(value.Name != String.Empty && value.Name.Length > 3) { 
                rol.Name = value.Name;
                rol.Status = value.Status != 0? value.Status : StatusRol.Active;
                context.RolUsers.Add(rol);
                await context.SaveChangesAsync();
            }
            else
            {
                res.Message = "Error!";
            }
            return res;
        }


    }
}
