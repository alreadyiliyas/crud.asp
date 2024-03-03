using BookStore.Core.Models;

namespace BookStore.Infrastructure
{
	public interface IJwtProvider
	{
		string GenerateToken(User user);
	}
}