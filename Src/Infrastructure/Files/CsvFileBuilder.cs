using System.Collections.Generic;
using System.IO;
using CsvHelper;
using Northwind.Application.Common.Interfaces;
using Northwind.Application.Products.Queries.GetProductsFile;

namespace Northwind.Infrastructure.Files
{
    internal class CsvFileBuilder : ICsvFileBuilder
    {
        public byte[] BuildProductsFile(IEnumerable<ProductRecordDto> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter);
                csvWriter.Configuration.RegisterClassMap<ProductFileRecordMap>();
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }
    }
}
