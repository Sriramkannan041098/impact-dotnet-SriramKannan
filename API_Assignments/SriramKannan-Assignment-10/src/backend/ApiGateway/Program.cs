using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var jwt = builder.Configuration.GetSection("Jwt");

builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o => o.TokenValidationParameters = 
      new TokenValidationParameters {
        ValidateIssuer = true, 
        ValidIssuer = jwt["Issuer"],
        ValidateAudience = true,
        ValidAudience = jwt["Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!)),
        ValidateLifetime = true, 
        ClockSkew = TimeSpan.FromSeconds(30), 
        RoleClaimType = "role"
     }
);

builder.Services.AddAuthorization();
builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Identity login/register are intentionally anonymous; gateway validates bearer tokens when present.
// Protect other routes at the gateway. Backend services independently validate tokens too.
app.MapReverseProxy(proxyPipeline => {
    proxyPipeline.Use(async (context, next) => {
        var path = context.Request.Path;
        var isIdentityPublic = path.StartsWithSegments("/identity/register") || path.StartsWithSegments("/identity/login");
        if (!isIdentityPublic && !context.User.Identity?.IsAuthenticated == true) {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsJsonAsync(new { message = "Bearer token required." });
            return;
        }
        await next();
    });
});

app.Run();
