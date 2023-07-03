using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.AppCore.DTOs.UserDTO;
using UserApp.AppCore.Results;
using UserApp.AppCore.Results.Bases;
using UserApp.BLL.Abstract;
using UserApp.DAL.Entities;
using UserApp.DAL.Repositories.Infrastructor;

namespace UserApp.BLL.Concrate
{
	public class UserManager : IUserManager
	{
		private readonly IUserRepository _repository;
		private readonly IMapper _mapper;

		public UserManager(IUserRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<Result> Add(AddUserDTO model)
		{
			var user = _mapper.Map<User>(model);
			var result = await _repository.AddAsync(user);
			
			if (result.IsSuccessful)
			{
				return new SuccessResult("User added successfully.");
			}

			return new ErrorResult($"User added error");

		}

		public Task<Result> Delete(UserDTO user)
		{
			throw new NotImplementedException();
		}

		public Task<Result> Delete(object id)
		{
			throw new NotImplementedException();
		}

		public List<UserDTO> GetAllUsers()
		{
			var userList = _repository.GetAllAsync();
			return _mapper.Map<List<UserDTO>>(userList);
		}

		public async Task<UserDTO> GetUser(object id)
		{
			var user = await _repository.GetByIdAsync(id);
			return _mapper.Map<UserDTO>(user);
		}

		//public Task<UserDTO> GetUserByName(string userName)
		//{
		//	throw new NotImplementedException();
		//}

		public async Task<Result> Update(object id, UpdateUserDTO model)
		{
			var user = await _repository.GetByIdAsync(id);
			user.Id = (int)id;
			user.Name = model.Name;
			user.Email = model.Email;
			user.UpdatedDate = DateTime.Now;

			var result = await _repository.Update(user);
			if (result.IsSuccessful) return new SuccessResult("User updated successfully.");

			return new ErrorResult($"User updated error");
		}
	}
}
