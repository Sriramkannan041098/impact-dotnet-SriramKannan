using System.Text;
using EduSphere.AcademicsService.Data;
using EduSphere.AcademicsService.Repositories;
using EduSphere.AcademicsService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AcademicsDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("AcademicsDb")));


builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();

var jwt = builder.Configuration.GetSection("Jwt");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o => {o.TokenValidationParameters = 
    new TokenValidationParameters {
        ValidateIssuer = true, ValidIssuer = jwt["Issuer"],
        ValidateAudience = true, ValidAudience = jwt["Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!)),
        ValidateLifetime = true, 
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
