using Microsoft.AspNetCore.Mvc;
using Quack.API.Models.Auth0;

namespace Quack.API.Controllers;

[ApiController]
[Route("[controller]")]
public class Auth0Controller : ControllerBase {
    private IConfiguration Configuration { get; }

    public Auth0Controller(IConfiguration configuration) {
        Configuration = configuration;
    }

    [HttpGet("configuration")]
    public ImplicitGrantConfigurationDto GetConfiguration() {
        return new ImplicitGrantConfigurationDto {
            ClientId = Configuration["Auth0:Domain"],
            Domain = Configuration["Auth0:ClientId"]
        };
    }
}
