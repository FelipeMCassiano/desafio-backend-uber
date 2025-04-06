# Email service

This project was built using C#, .NET Core and Amazon SES

## Instalation
1. Clone the repository
```bash
git clone https://github.com/FelipeMCassiano/desafio-backend-uber
```
2. Run ```bash dotnet restore```
3. Update `appsettings.Development.json` putting your AWS credentials
```json
{
  "Settings" : {
    "SES": {
      "AccessKey" : "**************",
      "SecretKey" : "**************************"
    }
  }
}
```
## Usage 
1. Start the app with ```bash dotnet run dotnet run --project /EmailService/src/Backend/EmailService.API
2. The api will be accessible at [http://localhost:5085/swagger/index.html](http://localhost:5085/swagger/index.html)

## API Endpoints
**SEND EMAIL**

```POST /emailservice/send ```

**BODY**
```json
{
  "to": "string",
  "subject": "string",
  "body": "string"
}
```
