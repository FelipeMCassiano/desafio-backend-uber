namespace Exceptions.ExceptionsBase;

public class ErrorOnValidationException : EmailSenderServiceExceptionBase
{
	private readonly  IList<string> _errorMessages;
	public ErrorOnValidationException(IList<string> errorMessages) : base(string.Empty)
	{
		_errorMessages = errorMessages;
		
	}

	public override IList<string> GetErrorMessage()
	{
		return _errorMessages;
	}
}