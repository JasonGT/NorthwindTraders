using System.Collections.Generic;

namespace Northwind.Application.Categories.Queries.GetCategoriesList
{
    /// <summary>
    /// Category view model.
    /// </summary>
    public class CategoriesListVm
    {
        /// <summary>
        /// Categories list.
        /// </summary>
        public IList<CategoryDto> Categories { get; set; }

        /// <summary>
        /// Total categories count.
        /// </summary>
        public int Count { get; set; }
    }
}
