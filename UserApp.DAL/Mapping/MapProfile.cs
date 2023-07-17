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

            CreateMap<UserDTO, UpdateUserDTO>();
            CreateMap<UpdateUserDTO, UserDTO>();

            CreateMap<AddUserDTO, User>();
			CreateMap<User, AddUserDTO>();

			CreateMap<UpdateUserDTO, User>();
			CreateMap<User, UpdateUserDTO>();
				
		}
	}
	
}
