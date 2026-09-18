using Microsoft.AspNetCore.Authentication;

namespace Cmf.CandidateTest.Api.Authentication;

public class ApiKeyAuthenticationOptions : AuthenticationSchemeOptions
{
    public const string DefaultScheme = "ApiKey";
}