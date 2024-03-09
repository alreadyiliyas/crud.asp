using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.DataAccess.Entities;
//Add-Migration test2 -Context BookStoreDbContext -Project 
//BookStore.DataAccess -StartupProject BookStore.API
public class UserEntity
{
	public Guid Id { get; set; }
	public string UserName { get; set; } = string.Empty;
	public string PasswordHash { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public int UserRoleId { get; set; } // Внешний ключ

	[ForeignKey("UserRoleId")] // Указание внешнего ключа для связи
	public RolesEntity Roles { get; set; } // Связь с таблицей Roles
}