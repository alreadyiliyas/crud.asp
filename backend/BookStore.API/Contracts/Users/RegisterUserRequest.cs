using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Contracts.Users
{
	public record RegisterUserRequest(
		[Required] string userName,
		[Required] string email,
		[Required] string password);
}
