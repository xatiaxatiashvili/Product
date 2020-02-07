using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.StockAdmin
{
    public class CreateStock
    {
        private ApplicationDbContext _context;

        public CreateStock(ApplicationDbContext context) => _context = context;
        public async Task<Response> Do(Request request)
        {
            var stock = new Stock
            {
                Name = request.Name,
                Qty=request.Qty,
                ProductId = request.ProductId
            };
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
            return new Response
            {
                Id = stock.Id,
                Name = stock.Name,
                Qty = stock.Qty
            };
        }
        public class Request
        {
            public int ProductId { get; set; }
            public string Name { get; set; }
            public int Qty { get; set; }           
        }
        public class Response
        {
            public int Id { get; set; }           
            public string Name { get; set; }           
            public int Qty { get; set; }           
        }
    }
}
