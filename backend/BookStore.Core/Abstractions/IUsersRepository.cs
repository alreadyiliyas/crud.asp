using BookStore.Core.Models;

namespace BookStore.DataAccess.Repositories
{
	public interface IUsersRepository
	{
		Task Add(User user);
		Task<User> GetByEmail(string email);
	}
}