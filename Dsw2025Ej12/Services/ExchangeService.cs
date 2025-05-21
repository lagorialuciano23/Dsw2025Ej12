using Dsw2025Ej12.Domain;
using Dsw2025Ej12.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej12.Services;

internal class ExchangeService
{
    public decimal GetAverageDollarQuote()
    {
        var quote1 = QuoteManager.GetDollarQuoteOptionOneAsync();
        var quote2 = QuoteManager.GetDollarQuoteOptionTwoAsync();
        var quote3 = QuoteManager.GetDollarQuoteOptionThreeAsync();

        var list = await Task.WhenAll(quote1, quote2, quote3);
        return list.Average();
    }

    public List<Product> GetProducts()
    {
        var products = new List<Product>();
        products.AddRange(DataManager.GetProducts()?
                .Select(p => new Product
                {
                    Code = p.Code,
                    Description = p.Description,
                    Price = p.Price
                }) ?? []);
        products.AddRange(DataService.GetProductsFromFile() ?? []);
        return products;
    }

    public async Task UpdatePrices()
    {
        var quote = await GetAverageDollarQuote();
        var products = GetProducts();
        products.ForEach(p => {
            p.UpdatePrice(quote);
            Console.WriteLine($"{p.DollarPrice:C2}");
        });
    }
}
