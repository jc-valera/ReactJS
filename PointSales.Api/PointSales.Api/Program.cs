using Jcvalera.Core.BLL;
using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.Common.Services;
using Jcvalera.Core.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PointSales.Api;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddScoped<IUserBLL, UserBLL>();
//builder.Services.AddScoped<IUserDAL, UserDAL> ();

//builder.Services.AddScoped<ICategoryBLL, CategoryBLL>();
//builder.Services.AddScoped<ICategoryDAL, CategoryDAL>();
builder.Services.AddApplicationServices();


// Add services to the container.
var appConfigSection = builder.Configuration.GetSection("AppConfig");
builder.Services.Configure<AppSettings>(appConfigSection);

var appSettings = appConfigSection.Get<AppSettings>();
var keyBytes = Encoding.UTF8.GetBytes(appSettings.SecretKey);

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //
    config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "API Punto de Ventas", Version = "v1" });
});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CORSPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("CORSPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
