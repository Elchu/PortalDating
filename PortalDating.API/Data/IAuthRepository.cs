using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using PortalDating.API.Models;

namespace PortalDating.API.Data
{
    public interface IAuthRepository
    {
        Task<User> Login(string username, string password);
        Task<User> Register(string username, string password);
        Task<bool> UserExists(string username);
    }
}
