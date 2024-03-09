namespace BookStore.Core.Models
{
	public class UserRoles
	{
		public UserRoles(int id, string roleName)
		{
			Id = id;
			RoleName = roleName;
		}
		public int Id { get; set; }
		public string RoleName { get; private set; }
	}
}
