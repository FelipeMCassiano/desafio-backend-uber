using Communication.Requests;
using EmailService.Application.Validators;
using EmailService.Domain.Services;
using Exceptions.ExceptionsBase;

namespace EmailService.Application.UseCase.EmailSend;

public class EmailSendUseCase : IEmailSendUseCase
{
	private readonly IEmailSender _emailSender;

	public EmailSendUseCase(IEmailSender emailSender)
	{
		_emailSender = emailSender;
	}

	public async Task SendEmail(RequestSendEmail request)
	{
		Validate(request);
		await _emailSender.SendEmail(request);
	}

	private static void Validate(RequestSendEmail request)
	{
		var validationResult = RequestSendEmailValidator.Validate(request);

		if (!validationResult.Any()) return;
		
		
		throw new ErrorOnValidationException(validationResult);
	}
}