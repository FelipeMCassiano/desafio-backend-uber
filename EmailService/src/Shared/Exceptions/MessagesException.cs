namespace Exceptions;

public static class MessagesException
{
	public const string InvalidEmail = "Invalid email address";
	public const string BodyEmpty = "Email body cannot be empty";
	public const string SubjectEmpty = "Email subject cannot be empty";
	public const string SubjectExceedLength = "Subject exceeds length";
	public const string BodyExceedLength = "Body exceeds length";
}