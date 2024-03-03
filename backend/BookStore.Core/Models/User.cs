namespace BookStore.Core.Models
{
	public class User
	{

		public const int MAX_USERNAME_LENGTH = 20;
		public const int MIN_USERNAME_LENGTH = 4;
		private User(Guid id, string userName, string passwordHash, string email)
		{
			Id = id;
			UserName = userName;
			PasswordHash = passwordHash;
			Email = email;
		}
		public Guid Id { get; set; }
		public string UserName { get; private set; }
		public string PasswordHash { get; private set;}
		public string Email { get; private set;}
		//public static User Create(Guid id, string userName, string passwordHash, string email)
		//{
		//	return new User(id, userName, passwordHash, email);
		//}
		public static User Create(Guid id, string userName, string passwordHash, string email)
		{
			//var error = string.Empty;

			//if (string.IsNullOrEmpty(userName) 
			//	|| (userName.Length > MAX_USERNAME_LENGTH 
			//	|| userName.Length < MIN_USERNAME_LENGTH)) 
			//{
			//	error = $"Username can not be empty or less then {MIN_USERNAME_LENGTH} or longer {MAX_USERNAME_LENGTH}";
			//}

			var user = new User(id, userName, passwordHash, email);

			return user;
		}
	}
}
