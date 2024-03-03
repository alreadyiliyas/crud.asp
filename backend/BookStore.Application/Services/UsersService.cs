using BookStore.Core.Models;
using BookStore.DataAccess.Repositories;
using BookStore.Infrastructure;

namespace BookStore.Application.Services
{
	public class UsersService
	{
		private readonly IPasswordHasher _passwordHasher;
		private readonly IUsersRepository _usersRepository;
		private readonly IJwtProvider _jwtProvider;

		public UsersService(
			IUsersRepository usersRepository, 
			IPasswordHasher passwordHasher,
			IJwtProvider jwtProvider)
		{
			_passwordHasher = passwordHasher;
			_usersRepository = usersRepository;
			_jwtProvider = jwtProvider ?? throw new ArgumentNullException(nameof(jwtProvider));
		}
		public async Task Register(string userName, string email, string password)
		{
			var hashPassword = _passwordHasher.Generate(password);

			var user = User.Create(Guid.NewGuid(), userName, hashPassword, email);

			await _usersRepository.Add(user);
		}

		public async Task<string> Login(string email, string password)
		{
			var user = await _usersRepository.GetByEmail(email);

			var result = _passwordHasher.Verify(password, user.PasswordHash);

			if(result == false)
			{
				throw new Exception("Failed to login");
			}

			var token = _jwtProvider.GenerateToken(user);

			return token;
		}
	}
}
