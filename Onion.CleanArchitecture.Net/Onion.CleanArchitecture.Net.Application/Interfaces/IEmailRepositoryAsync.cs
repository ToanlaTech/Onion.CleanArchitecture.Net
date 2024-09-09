
using Onion.CleanArchitecture.Net.Application.DTOs.Email;
using System.Threading.Tasks;

namespace Onion.CleanArchitecture.Net.Application.Interfaces
{
    public interface IEmailRepositoryAsync
    {
        Task SendMailToQueue(SendEmailRequest emailRequest);
    }
}
