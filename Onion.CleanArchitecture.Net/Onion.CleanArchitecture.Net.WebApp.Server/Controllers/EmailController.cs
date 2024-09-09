using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Onion.CleanArchitecture.Net.WebApp.Server.Controllers
{
    [Authorize]
    [Route("api/Email")]
    public class EmailController : BaseApiController
    {
        [Obsolete]
        public EmailController(
           Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment) : base(hostingEnvironment)
        {
        }
        /// <summary>
        /// Post send Email
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/v1/Email/send-mail
        ///     {
        ///        "emailTo": "A",
        ///        "emailCc": 1,
        ///        "tenTTKD": 1,
        ///        "diem": 1
        ///     }
        ///
        /// </remarks>
        /// 
        // [HttpPost()]
        // // [AllowAnonymous]
        // public async Task<IActionResult> Create(SendMailToOneEndPointCommand command)
        // {
        //     return Ok(await Mediator.Send(command));
        // }
    }
}
