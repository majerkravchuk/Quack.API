
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Quack.API.Data;
using Quack.API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppIdentityDbContext>(opts => {
    opts.UseNpgsql(
        Environment.GetEnvironmentVariable("IdentityConnection") ??
        builder.Configuration["ConnectionStrings:IdentityConnection"]);
});
builder.Services.AddDefaultIdentity<ApplicationUser>(options => {
        options.SignIn.RequireConfirmedAccount = true;
    })
    .AddEntityFrameworkStores<AppIdentityDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, AppIdentityDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

// ---- было

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}
else {
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseIdentityServer();
app.UseAuthorization();

app.MapControllers();

app.Run();
