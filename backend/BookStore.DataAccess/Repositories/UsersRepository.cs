using AutoMapper;
using BookStore.Core.Models;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repositories
{
	public class UsersRepository : IUsersRepository
	{
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;

		public UsersRepository(BookStoreDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task Add(User user)
		{
			var userEntity = new UserEntity()
			{
				Id = user.Id,
				UserName = user.UserName,
				PasswordHash = user.PasswordHash,
				Email = user.Email
			};

			await _context.Users.AddAsync(userEntity);
			await _context.SaveChangesAsync();
		}

		public async Task<User> GetByEmail(string email)
		{
			var userEntity = await _context.Users
				.AsNoTracking()
				.FirstOrDefaultAsync(x => x.Email == email) ?? throw new Exception();

			return _mapper.Map<User>(userEntity);
		}

	}
}
