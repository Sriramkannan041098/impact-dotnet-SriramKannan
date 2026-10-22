using System.Text;
using EduSphere.IdentityService.Data;
using EduSphere.IdentityService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IIdentityRepository, IdentityRepository>();

builder.Services.AddScoped<IIdentityService, IdentityService>();

builder.Services.AddSingleton<IPasswordHasher, Pbkdf2PasswordHasher>();

var jwt = builder.Configuration.GetSection("Jwt");
var key = jwt["Key"] ?? throw new InvalidOperationException("Jwt:Key is required.");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true, 
        ValidIssuer = jwt["Issuer"],
        ValidateAudience = true, 
        ValidAudience = jwt["Audience"],
        ValidateIssuerSigningKey = true, 
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
        ValidateLifetime = true, 
        ClockSkew = TimeSpan.FromSeconds(30),
        RoleClaimType = "role", 
        NameClaimType = "sub"
    };
});
builder.Services.AddAuthorization();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
