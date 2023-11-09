using ApplicationLayer.Interfaces;
using DomainLayer.Entities;
using InfrastructureLayer.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InfrastructureLayer.Common.Repositories;

namespace InfrastructureLayer.Repositories
{
	public class CategoryRepository : BaseRepository<Category> , ICategoryRepository
	{
		private readonly ApplicationDbContext _context;
		public CategoryRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}


		public async Task<IEnumerable<SelectListItem>> GetSelectList()
		{
			return await _context.Categories
				.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
				.OrderBy(c => c.Text)
				.ToListAsync();
		}
	}
}
