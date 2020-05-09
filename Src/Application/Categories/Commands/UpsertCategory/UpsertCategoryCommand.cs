using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northwind.Application.Common.Interfaces;
using Northwind.Domain.Entities;

namespace Northwind.Application.Categories.Commands.UpsertCategory
{
    /// <summary>
    /// Update category model.
    /// </summary>
    public class UpsertCategoryCommand : IRequest<int>
    {
        /// <summary>
        /// Id or null.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Base64 encoded data of a picture.
        /// </summary>
        public byte[] Picture { get; set; }

        public class UpsertCategoryCommandHandler : IRequestHandler<UpsertCategoryCommand, int>
        {
            private readonly INorthwindDbContext _context;

            public UpsertCategoryCommandHandler(INorthwindDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpsertCategoryCommand request, CancellationToken cancellationToken)
            {
                Category entity;

                if (request.Id.HasValue)
                {
                    entity = await _context.Categories.FindAsync(request.Id.Value);
                }
                else
                {
                    entity = new Category();

                    _context.Categories.Add(entity);
                }

                entity.CategoryName = request.Name;
                entity.Description = request.Description;
                entity.Picture = request.Picture;

                await _context.SaveChangesAsync(cancellationToken);

                return entity.CategoryId;
            }
        }
    }
}
