using Communication.Requests;

namespace EmailService.Application.UseCase.EmailSend;

public interface IEmailSendUseCase
{
	Task SendEmail(RequestSendEmail request);

}