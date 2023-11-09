using DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApplicationLayer.Common.Interfaces;

namespace ApplicationLayer.Interfaces
{
	public interface ICategoryRepository : IBaseRepository<Category>
	{
		Task<IEnumerable<SelectListItem>> GetSelectList();
	}
}
