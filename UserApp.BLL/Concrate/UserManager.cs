using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using UserApp.AppCore.DTOs.UserDTO;
using UserApp.AppCore.Results;
using UserApp.AppCore.Results.Bases;
using UserApp.BLL.Abstract;
using UserApp.DAL.Entities;
using UserApp.DAL.Repositories.Infrastructor;
using UserApp.DAL.Repositories;

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
			var result = _repository.AddAsync(user);

			//DataManager dataManager = new DataManager();
			//var data = dataManager.GetUserRepository();
			//data.AddAsync(user);

			if (result.IsSuccessful)
			{
				return new SuccessResult("User added successfully.");
			}

			return new ErrorResult($"User added error");

		}

		public async Task<Result> Delete(UserDTO user)
		{
			var model = _mapper.Map<User>(user);
			var result = await _repository.Delete(model);
			if (result.IsSuccessful)
			{
				return new SuccessResult("Used deleted successfully");
			}

			return new ErrorResult("user deleted error");
		}

		//public async Task<Result> Delete(object id)
		//{
		//	var user = await _repository.GetByIdAsync(id);
		//	var result = await _repository.Delete()
			
		//}

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
