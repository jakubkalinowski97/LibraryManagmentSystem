using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Library.Models;
using LibraryData;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class AccountController : Controller
    {

        private IAdmin _admin;

        public AccountController(IAdmin admin)
        {
            _admin = admin;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (LoginUser(loginModel.Username, loginModel.Password))
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginModel.Username)
            };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return Redirect("/");
            }
            return View();
        }

        private bool LoginUser(string username, string password)
        {
            var admin = _admin.GetByUsername(username);
            if(username == admin.Username && password == admin.Password)
            {
                return true;
            }
            return false;
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}