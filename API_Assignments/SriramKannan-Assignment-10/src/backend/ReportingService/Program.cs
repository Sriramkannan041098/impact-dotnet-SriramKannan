using System.Text;
using EduSphere.ReportingService.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ReportingDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("ReportingDb")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
var jwt = builder.Configuration.GetSection("Jwt");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    o => o.TokenValidationParameters = new TokenValidationParameters 
    {
      ValidateIssuer = true, 
      ValidIssuer = jwt["Issuer"], 
      ValidateAudience = true, 
      ValidAudience = jwt["Audience"],
      ValidateIssuerSigningKey = true, 
        
      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!)),
      ValidateLifetime = true, 
      RoleClaimType = "role"
    }
);
builder.Services.AddAuthorization();
var app = builder.Build();


app.UseSwagger(); 
app.UseSwaggerUI();
app.UseAuthentication(); 
app.UseAuthorization();
app.MapControllers();
app.Run();
