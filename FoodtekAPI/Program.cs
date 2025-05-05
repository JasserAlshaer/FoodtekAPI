using FoodtekAPI.Helpers.JWT;
using FoodtekAPI.interfaces;
using FoodtekAPI.Interfaces;
using FoodtekAPI.Models;
using FoodtekAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FoodtekDbContext>(option => option.UseSqlServer("Data Source=DESKTOP-QS28KQP\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"));

//Token
builder.Services.AddSingleton<TokenProviderHelper>();
// Add Authentication and Authorization with JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false; // for development
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:IssuerIP"],
            ValidAudience = builder.Configuration["JWT:AudienceIP"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            ClockSkew = TimeSpan.Zero // No extra time allowed after expiration
        };
    });
builder.Services.AddAuthorization();
var app = builder.Build();

//Token Also
app.UseAuthorization();
app.UseAuthentication();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
