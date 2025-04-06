using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Communication.Requests;
using EmailService.Domain.Services;
using Exceptions.ExceptionsBase;

namespace EmailService.Infrastructure.Services.EmailSender;

public class AmazonSimpleEmailSender : IEmailSender
{
	private readonly IAmazonSimpleEmailService _amazonSimpleEmailService;

	public AmazonSimpleEmailSender(IAmazonSimpleEmailService amazonSimpleEmailService)
	{
		_amazonSimpleEmailService = amazonSimpleEmailService;
	}

	public async Task SendEmail(RequestSendEmail request)
	{
		var emailRequest = new SendEmailRequest()
		{
			Source = "felipecassianofmc@gmail.com",
			Destination = new Destination()
			{
				ToAddresses = [ request.To ],
			},
			Message = new Message()
			{
				Body = new Body()
				{
					Text = new Content()
					{
						Charset = "UTF-8",
						Data = request.Body
					},
				},
				Subject = new Content()
				{
					Data = request.Subject,
				}
			}
		};
		
		try
		{
			var response = await _amazonSimpleEmailService.SendEmailAsync(emailRequest);
			Console.WriteLine(response.HttpStatusCode);
		}
		catch (AmazonSimpleEmailServiceException ex)
		{
			throw new ErrorOnSendingEmail(ex.Message);
		}
	}
}