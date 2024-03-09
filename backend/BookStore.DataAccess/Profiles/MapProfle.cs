using AutoMapper;
using BookStore.Core.Models;
using BookStore.DataAccess.Entities;

namespace BookStore.DataAccess.Profiles;

public class MapProfle : Profile
{
	public MapProfle()
	{
		CreateMap<UserEntity, User>().ReverseMap();
		CreateMap<RolesEntity, UserRoles>().ReverseMap();
	}
}