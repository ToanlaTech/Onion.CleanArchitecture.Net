using MediatR;
using Microsoft.AspNetCore.Identity;
using Onion.CleanArchitecture.Net.Application.Exceptions;
using Onion.CleanArchitecture.Net.Application.Wrappers;
using Onion.CleanArchitecture.Net.Infrastructure.Identity.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Onion.CleanArchitecture.Net.Infrastructure.Identity
{
    public class DeleteUserByIdCommand : IRequest<Response<ApplicationUser>>
    {
        public string Id { get; set; }
        public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, Response<ApplicationUser>>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            public DeleteUserByIdCommandHandler(UserManager<ApplicationUser> userManager)
            {
                _userManager = userManager;
            }
            public async Task<Response<ApplicationUser>> Handle(DeleteUserByIdCommand command, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByIdAsync(command.Id);
                if (user == null) throw new ApiException($"User Not Found.");
                await _userManager.DeleteAsync(user);
                return new Response<ApplicationUser>(user);
            }
        }
    }
}
