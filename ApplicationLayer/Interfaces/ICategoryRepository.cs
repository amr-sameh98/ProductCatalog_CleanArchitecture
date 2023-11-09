using DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApplicationLayer.Interfaces
{
	public interface ICategoryRepository : IBaseRepository<Category>
	{
		Task<IEnumerable<SelectListItem>> GetSelectList();
	}
}
