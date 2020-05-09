using CsvHelper.Configuration;
using Northwind.Application.Products.Queries.GetProductsFile;

namespace Northwind.Infrastructure.Files
{
    internal sealed class ProductFileRecordMap : ClassMap<ProductRecordDto>
    {
        public ProductFileRecordMap()
        {
            AutoMap();
            Map(m => m.UnitPrice).Name("Unit Price").ConvertUsing(c => (c.UnitPrice ?? 0).ToString("C"));
        }
    }
}
