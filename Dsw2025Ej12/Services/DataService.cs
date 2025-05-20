using Dsw2025Ej12.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej12.Services;

internal class DataService
{
    public static List<Product>? GetProductsFromFile()
    {
        var data = File.ReadAllText("Data\\Products.json");
        return System.Text.Json
        .JsonSerializer
            .Deserialize<List<Product>>(data);
    }
}
