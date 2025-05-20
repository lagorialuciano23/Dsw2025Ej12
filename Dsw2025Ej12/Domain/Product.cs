using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej12.Domain;

internal class Product
{
    public int Code { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public decimal DollarPrice { get; set; }

    public void UpdatePrice(decimal quote)
    {
        DollarPrice = Price / quote;
    }
}
