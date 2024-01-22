using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Sessions;
using WebApplication1.Users;

namespace WpfApp2.Sessions
{
    internal interface IAuthService
    {
        [Get("/auth")]
        Task<AccountDTO> Profile();

        [Post("/auth")]
        Task<TokenDTO> Login([Body] LoginDTO data, [Header("User-Agent")] string userAgent);

        [Delete("/auth")]
        Task Logout();

        [Post("/auth")]
        Task<TokenDTO> Register([Body] UserCreateDTO data, [Header("User-Agent")] string userAgent);
    }
}
