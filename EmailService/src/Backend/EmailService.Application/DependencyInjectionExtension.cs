using EmailService.Application.UseCase.EmailSend;
using Microsoft.Extensions.DependencyInjection;

namespace EmailService.Application;

public static class DependencyInjectionExtension
{
	public static void AddApplication(this IServiceCollection services)
	{
		AddUseCases(services);
	}

	private static void AddUseCases(IServiceCollection services)
	{
		services.AddScoped<IEmailSendUseCase, EmailSendUseCase>();
	}
	
}