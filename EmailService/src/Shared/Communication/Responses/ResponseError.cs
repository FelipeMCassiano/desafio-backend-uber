namespace Communication.Responses;

public class ResponseError
{
	public ResponseError(IList<string> errors)
	{
		Errors = errors;
		
	}
	
	public ResponseError(string error)
	{
		Errors = [error];
		
	}
	public IList<string> Errors { get; set; }
	
}