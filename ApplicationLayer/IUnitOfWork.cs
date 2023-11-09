using ApplicationLayer.Interfaces;

namespace ApplicationLayer
{
	public interface IUnitOfWork : IDisposable
	{
		//      IBaseRepository<Product> Products { get; }
		//IBaseRepository<Category> Categories { get; }
		IProductRepository Products { get; }
		ICategoryRepository Categories { get; }
		int Complete();
	}
}
