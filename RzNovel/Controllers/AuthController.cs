using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

using Microsoft.AspNetCore.Http;

using RzNovel.Services;
using RzNovel.DTO.Req;
using RzNovel.DTO.Resp;
using RzNovel.Common.Resp;

namespace RzNovel.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("login")]
        [HttpGet]
        public IActionResult SignIn()
        {
            string returnUrl = Request.Query["continue"];
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl)) return Redirect(returnUrl);
                return RedirectToAction("Index", "Home");
            }
                
            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<RestResp<UserLoginRespDto>>> PostSignIn(UserLoginReqDto dto)
        {
            RestResp<UserLoginRespDto> resp = await _userService.Login(dto);
            if (resp.data != null)
            {
                // auth success
                var claims = new List<Claim>
                    {
                        new Claim("Id", resp.data.id.ToString()),
                        new Claim(ClaimTypes.Name, resp.data.nickName),
                        new Claim(ClaimTypes.Role, resp.data.isAdmin ? "Admin" : "User"),
                    };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            }
            return resp;
        }

        [Route("logout")]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Route("register")]
        [HttpGet]
        public IActionResult Register()
        {
            string returnUrl = Request.Query["continue"];
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl)) return Redirect(returnUrl);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [Route("register")]
        [HttpPost]
        public async Task<ActionResult<RestResp<UserRegisterRespDto>>> PostRegister(UserRegisterReqDto dto)
        {
            RestResp<UserRegisterRespDto> resp = await _userService.Register(dto);
            return resp;
        }
    }
}
