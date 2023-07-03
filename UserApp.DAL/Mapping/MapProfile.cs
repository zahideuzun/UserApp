using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.AppCore.DTOs.UserDTO;
using UserApp.DAL.Entities;

namespace UserApp.DAL.Mapping
{
	public class MapProfile : Profile
	{
		public MapProfile()
		{
			CreateMap<UserDTO, User>();
			CreateMap<User, UserDTO>();

			CreateMap<AddUserDTO, User>()
				.ForMember(dest => dest.ImageURL, opt => opt.MapFrom(src => src.ImageURL.FileName));

			CreateMap<User, AddUserDTO>()
				.ForMember(dest => dest.ImageURL, opt => opt.Ignore())
				.AfterMap((src, dest) =>
				{
					dest.ImageURL = null;
				});

			CreateMap<UpdateUserDTO, User>()
				.ForMember(dest => dest.ImageURL, opt => opt.MapFrom(src => src.ImageURL.FileName));

			CreateMap<User, UpdateUserDTO>()
				.ForMember(dest => dest.ImageURL, opt => opt.Ignore())
				.AfterMap((src, dest) =>
				{
					dest.ImageURL = null;
				});
		}
	}
	
}
