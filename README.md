# XboxAPI.NET
Unofficial .NET client for XboxAPI. (https://xboxapi.com/)

## Build

XboxAPI.NET targets .NET Standard 2.0, making it compatible with projects built using .NET Core 2.0+ or .NET Framework 4.6.1+1.
You can build XboxAPI.NET by opening the solution in Visual Studio or from the command line using the 'dotnet build' command.

## XboxAPI Class
The XboxAPI class is used to issue requests to the XboxAPI service. In order to issue requests to the XboxAPI service, you'll need an
API key. You can obtain a free API key from https://xboxapi.com/, or upgrade to a paid subscription if you require support for a higher
volume of requests.

To use the XboxAPI class, call the constructor to initialize it with your API key, then call any of its methods to issue a request.
Each method corresponds to a call to a single endpoint in the REST API hosted on https://xboxapi.com/.
