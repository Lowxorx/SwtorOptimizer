﻿using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SwtorOptimizer.Models;

namespace SwtorOptimizer.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IJwtAuthManager jwtAuthManager;
        private readonly ILogger<AccountController> logger;
        private readonly IUserService userService;

        public AccountController(ILogger<AccountController> logger, IJwtAuthManager jwtAuthManager, IUserService userService)
        {
            this.logger = logger;
            this.jwtAuthManager = jwtAuthManager;
            this.userService = userService;
        }

        [HttpGet]
        [Authorize]
        [ActionName(nameof(GetCurrentUser))]
        public ActionResult GetCurrentUser()
        {
            return this.Ok(new LoginResult
            {
                UserName = this.User.Identity.Name,
                OriginalUserName = this.User.FindFirst("OriginalUserName")?.Value
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ActionName(nameof(Login))]
        public ActionResult Login([FromBody] LoginRequest request)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            if (!this.userService.IsValidUserCredentials(request.UserName, request.Password))
            {
                return this.Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.UserName),
            };

            var jwtResult = this.jwtAuthManager.GenerateTokens(request.UserName, claims, DateTime.Now);
            this.logger.LogInformation($"User [{request.UserName}] logged in the system.");
            return this.Ok(new LoginResult
            {
                UserName = request.UserName,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }

        [HttpPost]
        [Authorize]
        [ActionName(nameof(Logout))]
        public ActionResult Logout()
        {
            var userName = this.User.Identity.Name;
            this.jwtAuthManager.RemoveRefreshTokenByUserName(userName);
            this.logger.LogInformation($"User [{userName}] logged out the system.");
            return this.Ok();
        }

        [HttpPost]
        [Authorize]
        [ActionName(nameof(RefreshToken))]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            try
            {
                var userName = this.User.Identity.Name;
                this.logger.LogInformation($"User [{userName}] is trying to refresh JWT token.");

                if (string.IsNullOrWhiteSpace(request.RefreshToken))
                {
                    return this.Unauthorized();
                }

                var accessToken = await this.HttpContext.GetTokenAsync("Bearer", "access_token");
                var jwtResult = this.jwtAuthManager.Refresh(request.RefreshToken, accessToken, DateTime.Now);
                this.logger.LogInformation($"User [{userName}] has refreshed JWT token.");
                return this.Ok(new LoginResult
                {
                    UserName = userName,
                    AccessToken = jwtResult.AccessToken,
                    RefreshToken = jwtResult.RefreshToken.TokenString
                });
            }
            catch (SecurityTokenException e)
            {
                return this.Unauthorized(e.Message); // return 401 so that the client side can redirect the user to login page
            }
        }
    }
}