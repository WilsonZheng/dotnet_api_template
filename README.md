# Kata09 Solution (Backend)

A .Net Core web API for checkout logic in http://codekata.com/kata/kata09-back-to-the-checkout/

Environment set up: Download .Net SDK 8 and restart machine

# Command to set up project:

`dotnet new webapi -n kataApi`

# Start API server:

`cd WebApi && dotnet run`

# Set up unit tests dependencies:

`cd WebApi.Tests && dotnet add package Moq`
`cd WebApi.Tests && dotnet add package FluentAssertions`

# Local API URL and a Sample Request:

`http://localhost:5000/v1/checkout?items=ABA`

# Set up Unit Tests:

Follow guidance on https://code.visualstudio.com/docs/csharp/testing

# TODO(Improvement):

Better decoupling:
Use Dependencies Injection container

Security:
API level: Validate input, use authentication, log api requests
Infrastructure level: e.g. Use Azure/AWS Web Application Firewall
