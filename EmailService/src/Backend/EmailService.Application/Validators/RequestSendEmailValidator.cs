using System.ComponentModel.DataAnnotations;
using Communication.Requests;
using Exceptions;

namespace EmailService.Application.Validators;

public static class RequestSendEmailValidator
{
	public static IList<string> Validate(RequestSendEmail request)
	{
		var errors = new List<string>();
		
		if (string.IsNullOrEmpty(request.Subject))
		{
			errors.Add(MessagesException.SubjectEmpty);
		}

		if (string.IsNullOrEmpty(request.Body))
		{
			errors.Add(MessagesException.BodyEmpty);
		}

		var emailAttribute = new EmailAddressAttribute();
		if (!emailAttribute.IsValid(request.To))
		{
			errors.Add(MessagesException.InvalidEmail);
		}
		
		return errors;
	}
	
	
}