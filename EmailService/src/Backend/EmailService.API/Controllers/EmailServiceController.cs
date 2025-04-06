using Communication.Requests;
using Communication.Responses;
using EmailService.Application.UseCase.EmailSend;
using Microsoft.AspNetCore.Mvc;

namespace EmailService.API.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class EmailServiceController : ControllerBase
    {

	    [HttpPost("send")]
	    [ProducesResponseType(StatusCodes.Status200OK)]
	    [ProducesResponseType(typeof(ResponseError),StatusCodes.Status400BadRequest)]
	    public async Task<IActionResult> SendEmail([FromServices] IEmailSendUseCase useCase,
		    [FromBody] RequestSendEmail requestSendEmail)
	    {
		    await useCase.SendEmail(requestSendEmail);
		    return Ok();
	    }
	    
	    
    }

