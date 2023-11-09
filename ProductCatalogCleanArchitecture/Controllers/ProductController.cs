using ApplicationLayer;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductCatalogCleanArchitecture.Controllers
{
	public class ProductController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public ProductController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<IActionResult> GetAll(int id)
		{
			IEnumerable<SelectListItem> categories = await _unitOfWork.Categories.GetSelectList();
			ViewData["Categories"] = categories;
			return View(await _unitOfWork.Products.GetAll(id));
		}
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add()
        {
            AddProductFormViewModel viewModel = new()
            {
                Categories = await _unitOfWork.Categories.GetSelectList()
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddProductFormViewModel product)
        {
            if (!ModelState.IsValid)
            {
                product.Categories = await _unitOfWork.Categories.GetSelectList();
                return View(product);
            }
            await _unitOfWork.Products.Add(product);

            //return View(product);
            return RedirectToAction(nameof(GetAll));
        }
    }
}
