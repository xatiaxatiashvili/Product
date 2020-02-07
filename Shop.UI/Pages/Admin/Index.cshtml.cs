using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.ProductsAdmin;
using Shop.Database;
using static Shop.Application.ProductsAdmin.CreateProduct;
using static Shop.Application.ProductsAdmin.GetProducts;
using static Shop.Application.ProductsAdmin.DeleteProduct;
using Shop.Application.StockAdmin;

namespace Shop.UI.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _ctx;
        public IndexModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }   

        public IEnumerable<ProductViewModel> Products { get; set; }
        public void OnGet()
        {
            Products = new GetProducts(_ctx).Do();
        }

        [BindProperty]
        public Request Product { get; set; }
        [BindProperty]
        public CreateStock.Request Stock { get; set; }

        [HttpPost]
        public async Task<IActionResult> OnPost()
        {
            await new CreateProduct(_ctx).Do(Product);
            await new CreateStock(_ctx).Do(Stock);
            return RedirectToPage("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await new DeleteProduct(_ctx).Do(id);
            return RedirectToPage("Index");
        }

    }
}