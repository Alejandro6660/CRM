using CRM_Service.Context;
using CRM_Service.Entitys;
using CRM_Service.Enums;
using CRM_Service.Models;
using CRM_Service.Services.IManagers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Service.Services.Managers
{
    public class UserManager : IUserManager, IGeneralManager<UserModel, UserInsertModel>
    {
        private readonly CRMContext context;
        private readonly ISecurityBasic securityBasic;

        public UserManager(CRMContext context, ISecurityBasic securityBasic, IConfiguration configuration)
        {
            this.context = context;
            this.securityBasic = securityBasic;
        }
        public async Task<Response> Create(UserInsertModel poco)
        {
            var res = new Response();
            User user = new User();
            user.Name = poco.Name;
            user.LastName = poco.LastName;
            user.NameUser = poco.NameUser;
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
                    string encryptedPassword = await securityBasic.Encrypt(poco.Password);
                    user.Password = encryptedPassword;
                }
            }
            var rol = await General<RolUser, int>.GetObject(context, poco.RolUserId);
            user.Phone = poco.Phone;
            user.Address = poco.Address;
            user.RolUserId = poco.RolUserId;
            user.RolUser = rol;
            user.ZIP = poco.ZIP;
            user.RFC = poco.RFC;
            user.CreatedDate = DateTime.Now;
            user.IsPayroll = poco.IsPayroll;
            user.PhoneEmergency = poco.PhoneEmergency;
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
                rol.Status = StatusRol.Active;
                rol.Created = DateTime.Now;
                context.RolUsers.Add(rol);
                await context.SaveChangesAsync();
            }
            else
            {
                res.Message = "Error!";
            }
            return res;
        }

        public async Task<UserModel> Login(UserLoginModel login)
        {
            UserModel us = null; 
            if(login.UserName != String.Empty)
            {
                var user = await context.Users.FirstOrDefaultAsync(p => p.NameUser == login.UserName);
                if (user != null)
                {
                    if (await securityBasic.VerifyPassword(login.Password, user.Password))
                    {
                        var rol = await General<RolUser, int>.GetObject(context, user.RolUserId);
                        us = new UserModel();
                        us.Id = user.Id;
                        us.Name = user.Name;
                        us.LastName = user.LastName;
                        us.NameUser = user.NameUser;
                        us.RolUser = rol.Name;
                        us.Initials = user.Initials;
                        us.PathImg = "";
                        string IdUsuario = user.Id.ToString();
                        us.JWToken = await securityBasic.GetTokenJWT(IdUsuario, rol.Name);
                    }
                }
                else
                {
                    throw new Exception("Usuario No existente.");
                }
            }
            else
            {
                var user = await context.Users.FirstOrDefaultAsync(p => p.Email == login.Email);
                if (user != null)
                {
                    if (await securityBasic.VerifyPassword(login.Password, user.Password))
                    {
                        var rol = await General<RolUser, int>.GetObject(context, user.RolUserId);
                        us = new UserModel();
                        us.Id = user.Id;
                        us.Name = user.Name;
                        us.LastName = user.LastName;
                        us.NameUser = user.NameUser;
                        us.RolUser = rol.Name;
                        us.Initials = user.Initials;
                        us.PathImg = "";
                        string IdUsuario = user.Id.ToString();
                        us.JWToken = await securityBasic.GetTokenJWT(IdUsuario, rol.Name);
                    }
                }
                else
                {
                    throw new Exception("Usuario No existente.");
                }
            }
            return us;
        }
    }
}
