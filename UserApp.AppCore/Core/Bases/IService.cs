using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.AppCore.DTOs.UserDTO;
using UserApp.AppCore.Results.Bases;

namespace UserApp.AppCore.Core.Bases
{
    public interface IService<out TModel, in TAddModel, in TUpdateModel>  where TModel : new()
    {
        IQueryable<TModel> GetAll();
        TModel Get(int id);
        Result Add(TAddModel model);
        Result Update(int id, TUpdateModel model);
        Result Delete(int id);
        
    }
}
