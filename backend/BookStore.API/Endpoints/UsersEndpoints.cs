﻿using BookStore.API.Contracts.Users;
using BookStore.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Endpoints
{
	public static class UsersEndpoints
	{
		public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapPost("register", Register);
			app.MapPost("login", Login);

			return app;
		}

		private static async Task<IResult> Register(
			RegisterUserRequest request,
			UsersService usersService)
		{
			await usersService.Register(request.userName, request.email, request.password, request.userRole);

			return Results.Ok();
		}
		private static async Task<IResult> Login(
			LoginUserRequest request,
			UsersService usersService,
			HttpContext context)
		{
			var token = await usersService.Login(request.Email, request.Password);

			context.Response.Cookies.Append("tasty-cookies", token);
			return Results.Ok();
		}
	}
}
