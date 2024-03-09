using BookStore.Application.Services;
using BookStore.DataAccess;
using BookStore.DataAccess.Repositories;
using BookStore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BookStore.API.Endpoints;
using Microsoft.Extensions.Options;
using BookStore.DataAccess.Profiles;
using BookStore.API.Extensions;
using BookStore.Infrastructure.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookStoreDbContext>(
	options =>
	{
		options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(BookStoreDbContext)),
		x => x.MigrationsAssembly("BookStore.DataAccess"));
	});


builder.Services.AddScoped<IBooksRepository, BooksRepository>();
builder.Services.AddScoped<IBooksServices, BooksServices>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

builder.Services.AddScoped<UsersService>();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
builder.Services.AddApiAuthentication(builder.Configuration);	
builder.Services.AddAutoMapper(typeof(MapProfle));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseCookiePolicy(new CookiePolicyOptions
{
	MinimumSameSitePolicy = SameSiteMode.Strict,
	HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
	Secure = CookieSecurePolicy.Always
});


app.UseAuthentication();
app.UseAuthorization();

app.MapUsersEndpoints();
app.MapControllers();
app.UseCors(x =>
{
	x.WithHeaders().AllowAnyHeader();
	x.WithOrigins("http://localhost:3000");
	x.WithMethods().AllowAnyMethod();
});

app.MapGet("get", () =>
{
	return Results.Ok("ok");
}).RequireAuthorization("AdminPolicy");

app.Run();
