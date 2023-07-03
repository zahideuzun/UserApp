using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.AppCore.Core.Bases;

namespace UserApp.DAL.Entities.Bases
{
	public class BaseEntity : IEntity
	{
		public int Id { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime? UpdatedDate { get; set; }
		public bool IsDeleted { get; set; } = false;
		public bool IsActive { get; set; } = true;
	}
}
