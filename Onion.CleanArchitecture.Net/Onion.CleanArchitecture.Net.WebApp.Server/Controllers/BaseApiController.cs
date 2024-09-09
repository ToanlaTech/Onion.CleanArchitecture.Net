﻿using Casbin;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Onion.CleanArchitecture.Net.Application.Exceptions;
using System.Security.Claims;


namespace Onion.CleanArchitecture.Net.WebApp.Server.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected readonly Enforcer _enforcer;
        protected readonly string _webRootPath;

        [Obsolete]
        public BaseApiController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _webRootPath = hostingEnvironment.WebRootPath;
            _enforcer = new Enforcer(Path.Combine(_webRootPath, "model.conf"), Path.Combine(_webRootPath, "policy.csv"));
        }

        protected async Task<IActionResult> EnforcePermissionAndExecute(string resource, string action, Func<Task<IActionResult>> func)
        {
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var userPermission = identity.FindFirst("permission")?.Value;

                var enforcer = await _enforcer.EnforceAsync(userPermission, resource, action);
                if (!enforcer)
                {
                    throw new ApiException("You do not have permission to perform this action.", 403);
                }
                return await func();
            }
            throw new ApiException("You are not Authorized", 401);
        }
    }
}
