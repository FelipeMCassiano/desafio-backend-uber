namespace Exceptions.ExceptionsBase;

public abstract class EmailSenderServiceExceptionBase : SystemException
{
	protected EmailSenderServiceExceptionBase(string message) : base(message)
	{
		
	}
	public  abstract IList<string> GetErrorMessage();
}