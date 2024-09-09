using Casbin;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Onion.CleanArchitecture.Net.Application.Wrappers;
using Onion.CleanArchitecture.Net.Infrastructure.Identity.Contexts;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Onion.CleanArchitecture.Net.Infrastructure.Identity.Features.RoleClaim.Commands.DeleteRoleClaimById
{
    public class DeleteRoleClaimByIdCommand : IRequest<Response<IdentityRoleClaim<string>>>
    {
        public int Id { get; set; }

        public class DeleteRoleClaimByIdCommandHandler : IRequestHandler<DeleteRoleClaimByIdCommand, Response<IdentityRoleClaim<string>>>
        {
            private readonly Enforcer _enforcer;
            private readonly string _webRootPath;
            private readonly IdentityContext _context;

            [Obsolete]
            public DeleteRoleClaimByIdCommandHandler(
                IdentityContext context,
                IHostingEnvironment hostingEnvironment)
            {
                _webRootPath = hostingEnvironment.WebRootPath;
                _context = context;
                _enforcer = new Enforcer(Path.Combine(_webRootPath, "model.conf"), Path.Combine(_webRootPath, "policy.csv"));
            }
            public async Task<Response<IdentityRoleClaim<string>>> Handle(DeleteRoleClaimByIdCommand request, CancellationToken cancellationToken)
            {
                var roleClaim = _context.RoleClaims.Find(request.Id);
                if (roleClaim == null) throw new Exception($"RoleClaim Not Found.");
                var role = await _context.Roles.FindAsync(roleClaim.RoleId);
                await _enforcer.RemoveFilteredPolicyAsync(0, role.Name, roleClaim.ClaimType);
                await _enforcer.SavePolicyAsync();
                _context.RoleClaims.Remove(roleClaim);
                _context.SaveChanges();
                return new Response<IdentityRoleClaim<string>>(roleClaim);
            }
        }
    }
}
