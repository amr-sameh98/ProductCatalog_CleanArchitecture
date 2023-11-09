using DomainLayer.Entities;
using ApplicationLayer.ViewModels;
using ApplicationLayer.Common.Interfaces;

namespace ApplicationLayer.Interfaces
{
	public interface IProductRepository : IBaseRepository<Product>
	{
		Task<Product> Add(AddProductFormViewModel product);
		Task Delete(int id);
		Task<List<Product>> GetAll(int? categoryId = null);
		Task<List<Product>> GetAllInDuration(int? categoryId = null);
		Task<Product?> GetById(int id);
		Task<AddProductFormViewModel> Edit(AddProductFormViewModel product);
	}
}
