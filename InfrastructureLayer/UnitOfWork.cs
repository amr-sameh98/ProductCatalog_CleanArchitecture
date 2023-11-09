using ApplicationLayer;
using ApplicationLayer.Interfaces;
using InfrastructureLayer.Data;
using InfrastructureLayer.Repositories;

namespace InfrastructureLayer
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;

		public IProductRepository Products { get; private set; }
		public ICategoryRepository Categories { get; private set; }
		//      public IBaseRepository<Product> Products { get; private set; }
		//public IBaseRepository<Category> Categories { get; private set; }

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;

			//Products = new BaseRepository<Product>(_context);
			//Categories = new BaseRepository<Category>(_context);

			Products = new ProductRepository(_context);
			Categories = new CategoryRepository(_context);

		}
		public int Complete()
		{
			return _context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
