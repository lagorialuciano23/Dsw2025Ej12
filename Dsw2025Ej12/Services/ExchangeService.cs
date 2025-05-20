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
        var quote1 = QuoteManager.GetDollarQuoteOptionOne();
        var quote2 = QuoteManager.GetDollarQuoteOptionTwo();
        var quote3 = QuoteManager.GetDollarQuoteOptionThree();

        var list = new[] { quote1, quote2, quote3 };
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

    public void UpdatePrices()
    {
        var quote = GetAverageDollarQuote();
        var products = GetProducts();
        products.ForEach(p => p.UpdatePrice(quote));
    }
}
