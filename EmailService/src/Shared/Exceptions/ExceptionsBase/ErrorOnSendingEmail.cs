namespace Exceptions.ExceptionsBase;

public class ErrorOnSendingEmail : EmailSenderServiceExceptionBase 
{
	public ErrorOnSendingEmail(string message) : base(message)
	{
	}

	public override IList<string> GetErrorMessage()
	{
		return [Message];
	}
}