using Communication.Requests;

namespace EmailService.Domain.Services;

public interface IEmailSender 
{
	Task SendEmail(RequestSendEmail request);
}