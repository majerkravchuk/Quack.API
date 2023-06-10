using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using Quack.API.Models;

namespace Quack.API.Data;

public class AppIdentityDbContext : ApiAuthorizationDbContext<ApplicationUser> {
     public AppIdentityDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
         : base(options, operationalStoreOptions) { }
}
