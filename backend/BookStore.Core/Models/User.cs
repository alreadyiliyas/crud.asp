namespace BookStore.Core.Models
{
	public class User
	{

		public const int MAX_USERNAME_LENGTH = 20;
		public const int MIN_USERNAME_LENGTH = 4;
		private User(Guid id, string userName, string passwordHash, string email, int userRoleId)
		{
			Id = id;
			UserName = userName;
			PasswordHash = passwordHash;
			Email = email;
			UserRoleId = userRoleId;
		}
		public Guid Id { get; set; }
		public string UserName { get; private set; }
		public string PasswordHash { get; private set;}
		public string Email { get; private set;}

		public int UserRoleId { get; private set; }
		public static User Create(Guid id, string userName, string passwordHash, string email, int UserRoleId)
		{
			var user = new User(id, userName, passwordHash, email, UserRoleId);
			return user;
		}
	}
}
