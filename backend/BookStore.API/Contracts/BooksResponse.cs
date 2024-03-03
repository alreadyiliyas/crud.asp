namespace newBookStore.API.Contracts
{
	public record BooksResponse(
		Guid Id,
		string Title,
		string Description,
		decimal Price);
}
