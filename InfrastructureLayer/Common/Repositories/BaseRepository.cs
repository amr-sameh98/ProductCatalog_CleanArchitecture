using ApplicationLayer.Common.Interfaces;
using InfrastructureLayer.Data;

namespace InfrastructureLayer.Common.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		protected ApplicationDbContext _context;

		public BaseRepository(ApplicationDbContext context)
		{
			_context = context;
		}
	}
}
