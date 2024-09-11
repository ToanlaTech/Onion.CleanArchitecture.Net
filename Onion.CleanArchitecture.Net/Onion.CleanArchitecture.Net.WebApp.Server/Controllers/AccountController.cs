﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.CleanArchitecture.Net.Application.DTOs.Account;
using Onion.CleanArchitecture.Net.Application.Exceptions;
using Onion.CleanArchitecture.Net.Application.Interfaces;
using Onion.CleanArchitecture.Net.Infrastructure.Identity.Features.Users.Queries.GetMeByToken;
using System.Security.Claims;

namespace Onion.CleanArchitecture.Net.WebApp.Server.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;

        [Obsolete]
        public AccountController(IAccountService accountService, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment) : base(hostingEnvironment)
        {
            _accountService = accountService;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _accountService.AuthenticateAsync(request, GenerateIPAddress()));
        }

        [HttpPost("authen")]
        public async Task<IActionResult> AuthenWithoutPasswordAsync(AuthenticationRequest request)
        {
            return Ok(await _accountService.AuthenWithoutPasswordAsync(request.Email, GenerateIPAddress()));
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUserAsync()
        {

            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                return Ok(await Mediator.Send(new GetMeByTokenQuery { Identity = identity }));
            }
            else
            {
                throw new ApiException("User not found", 404);
            }

        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.RegisterAsync(request, origin));
        }
        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmailAsync([FromQuery] string userId, [FromQuery] string code)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.ConfirmEmailAsync(userId, code));
        }
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest model)
        {
            await _accountService.ForgotPassword(model, Request.Headers["origin"]);
            return Ok();
        }
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest model)
        {

            return Ok(await _accountService.ResetPassword(model));
        }
        private string? GenerateIPAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
        }
    }
}