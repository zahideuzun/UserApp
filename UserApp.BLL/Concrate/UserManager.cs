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
using UserApp.DAL.Repositories.Derived;
using UserApp.AppCore.Core.Bases;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace UserApp.BLL.Concrate
{
    public class UserManager : IUserManager
    {
        private readonly UserRepository _repository;
        private readonly IMapper _mapper;

        public UserManager(UserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Result Add(AddUserDTO model)
        {
            if (_repository.Query().Any(c => c.Email.ToLower() == model.Email.ToLower().Trim()))
                return new ErrorResult("User can't be added because user with the same email address exists!");
            var entity = _mapper.Map<User>(model);
            _repository.Add(entity);
            return new SuccessResult();
        }

        public async Task<Result> AddAsync(AddUserDTO model)
        {
            if (_repository.Query().Any(c => c.Email.ToLower() == model.Email.ToLower().Trim()))
                return new ErrorResult("User can't be added because user with the same email address exists!");
            var entity = _mapper.Map<User>(model);
             await _repository.AddAsync(entity);
                return new SuccessResult("User added successfully.");
        }

        public async Task<Result> DeleteAsync(UserDTO user)
        {
            // iliskili oldugu tablo olursa burada query ile kontrol edip silinmeyi engelleyebilirsin!
            if (Get(user.Id) != null)
            {
                var model = _mapper.Map<User>(user);
                await _repository.Delete(model);
                return new SuccessResult("User deleted successfully.");
            }
            return new ErrorResult("User not found");
        }

        public Result Delete(int id)
        {
            if (Get(id) != null)
            {
                _repository.Delete(id);
                return new SuccessResult("User deleted successfully.");
            }
            return new ErrorResult("User not found");
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public UserDTO Get(int id)
        {
            var user = _repository.GetById(id);
            return _mapper.Map<UserDTO>(user);
        }

        public IQueryable<UserDTO> GetAll()
        {
            var userList = _repository.GetAll();
            return _mapper.Map<List<UserDTO>>(userList).AsQueryable();
        }

        public async Task<UserDTO> GetUser(object id)
        {
            var user = await _repository.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<Result> UpdateAsync(int id, UpdateUserDTO model)
        {
            //TODO validationlar burada UpdateUserDto üzerinden yapilacak.
            var user = _repository.GetById(id);
            if (user.Id != null)
            {
                user.Id = id;
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.ImageURL = model.ImageURL;
                user.UpdatedDate = DateTime.Now;

                await _repository.Update(user);
                return new SuccessResult("User updated successfull!");
            }
                return new ErrorResult("User not found!");
        }

        public Result Update(int id, UpdateUserDTO model)
        {
            //TODO validationlar burada UpdateUserDto üzerinden yapilacak.
            var user = _repository.GetById(id);
            if (user.Id != null)
            {
                user.Id = id;
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.ImageURL = model.ImageURL;
                user.UpdatedDate = DateTime.Now;

                _repository.Update(user);
                return new SuccessResult("User updated successfull!");
            }
            return new ErrorResult("User not found!");
        }

        public async Task<Result> DeleteAsync(int id)
        {
            if (Get(id) != null)
            {
                await _repository.Delete(id);
                return new SuccessResult("User deleted successfully.");
            }
            return new ErrorResult("User not found");
        }
    }
}
