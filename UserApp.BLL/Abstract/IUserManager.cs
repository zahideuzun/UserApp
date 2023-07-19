using UserApp.AppCore.Core.Bases;
using UserApp.AppCore.DTOs.UserDTO;
using UserApp.AppCore.Results.Bases;

namespace UserApp.BLL.Abstract
{
    public interface IUserManager : IService<UserDTO, AddUserDTO,UpdateUserDTO>
	{
        Task<UserDTO> GetUser(object id);
        Task<Result> AddAsync(AddUserDTO model);
        Task<Result> UpdateAsync(int id, UpdateUserDTO model);
        Task<Result> DeleteAsync(UserDTO user);
        Task<Result> DeleteAsync(int id);
    }
}
