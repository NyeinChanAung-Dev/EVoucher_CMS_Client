using EVoucher_CMS_Client.APIRepo;
using EVoucher_CMS_Client.Models.RequestModels;
using EVoucher_CMS_Client.Models.ResponseModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EVoucher_CMS_Client.Controllers
{
    public class UserAuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequest _request)
        {
            if (!string.IsNullOrEmpty(_request.LoginId) && string.IsNullOrEmpty(_request.Password))
            {
                return RedirectToAction("Login");
            }

            string Url = "api/userauth/login";
            LoginResponse response = await APIRequest.PostLogin(Url, _request);

            ClaimsIdentity identity = null;
            bool isAuthenticated = false;

            if (response != null)
            {
                identity = CreateClaimsIdentity(response);
                isAuthenticated = true;
                ViewBag.Unauthorize = "Authorize";
            }
            else
            {
                ViewBag.Unauthorize = "Unauthorize";
            }

            if (isAuthenticated)
            {
                var principal = new ClaimsPrincipal(identity);

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "EVoucher");
            }
            return View();
        }


        private ClaimsIdentity CreateClaimsIdentity(LoginResponse result)
        {
            var claims = new Claim[]
            {
                new Claim("ct:Custom:accessToken", result.AccessToken),
                new Claim("ct:Custom:accessTokenExpireMinutes", result.AccessTokenExpireMinutes.ToString()),
                new Claim("ct:Custom:refreshToken", result.RefreshToken),
                new Claim("ct:Custom:refreshTokenExpireMinutes", result.RefreshTokenExpireMinutes.ToString()),
            };

            return new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        }

    }
}
