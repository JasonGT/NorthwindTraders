using AutoMapper;
using Northwind.Application.Common.Mappings;
using Northwind.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Application.Categories.Queries.GetCategoriesList
{
    /// <summary>
    /// Category.
    /// </summary>
    /// <example>{ "id": 1, "name": "Sea food" } </example>
    public class CategoryDto : IMapFrom<Category>
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        /// <example>"Sea food"</example>
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Picture.
        /// </summary>
        public byte[] Picture { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.CategoryId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.CategoryName));
        }
    }
}
