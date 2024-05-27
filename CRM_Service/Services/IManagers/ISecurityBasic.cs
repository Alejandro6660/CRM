using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Service.Services.IManagers
{
    public interface ISecurityBasic
    {
        Task<string> Encrypt(string password);
        Task<bool> VerifyPassword(string password, string hashedPassword);
        Task<string>GetTokenJWT(string IdUsuario, string RolUsuario);
    }
}
