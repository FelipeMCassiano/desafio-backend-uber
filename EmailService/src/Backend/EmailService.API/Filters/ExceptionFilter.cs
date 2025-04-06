using Communication.Responses;
using Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmailService.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
	public void OnException(ExceptionContext context)
	{
		var exception = context.Exception;

		if (exception is EmailSenderServiceExceptionBase emailSenderServiceException)
		{
			HandleProjectException(emailSenderServiceException, context);
			return;
			
		}
		ThrowUnknownException(context);
	}

	private static void HandleProjectException(EmailSenderServiceExceptionBase emailSenderServiceException,
		ExceptionContext
			context)
	{
		switch (emailSenderServiceException)
		{
			case ErrorOnValidationException errorOnValidationException:
				context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
				context.Result = new BadRequestObjectResult(new ResponseError(errorOnValidationException.GetErrorMessage()));
				break;
			case ErrorOnSendingEmail errorOnSendingEmail:
				context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
				context.Result = new BadRequestObjectResult(new ResponseError(errorOnSendingEmail.GetErrorMessage()));
				break;
		}
	}

	private static void ThrowUnknownException(ExceptionContext context)
	{
		context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
		context.Result = new ObjectResult(new ResponseError(context.Exception.Message));
	}
}