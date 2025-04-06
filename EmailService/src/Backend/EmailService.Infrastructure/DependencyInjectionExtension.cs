using Amazon;
using Amazon.Runtime;
using Amazon.SimpleEmail;
using EmailService.Domain.Services;
using EmailService.Infrastructure.Services.EmailSender;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmailService.Infrastructure;

public static class DependencyInjectionExtension
{
	public static void AddInfrastructure(this IServiceCollection services,  IConfiguration configuration)
	{
		AddEmailSenderService(services, configuration);
	}

	private static void AddEmailSenderService(this IServiceCollection services, IConfiguration configuration)
	{
		var accessKey = configuration.GetValue<string>("Settings:SES:AccessKey");
		var secretKey = configuration.GetValue<string>("Settings:SES:SecretKey");
		
		var regionEndpoint = RegionEndpoint.USEast1;
		
		var client = new AmazonSimpleEmailServiceClient(accessKey, secretKey, region: regionEndpoint);
		services.AddSingleton<IAmazonSimpleEmailService>(_ => client);
		
		
		services.AddScoped<IEmailSender, AmazonSimpleEmailSender>();
	}
	
}