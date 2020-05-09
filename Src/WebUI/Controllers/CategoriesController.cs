using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Categories.Commands.DeleteCategory;
using Northwind.Application.Categories.Commands.UpsertCategory;
using Northwind.Application.Categories.Queries.GetCategoriesList;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Northwind.WebUI.Controllers
{
    [Authorize]
    public class CategoriesController : BaseController
    {
        /// <summary>
        /// Get all gategories.
        /// </summary>
        /// <returns>Returns list of all categories.</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<CategoriesListVm>> GetAll()
        {
            return Ok(await Mediator.Send(new GetCategoriesListQuery()));
        }

        /// <summary>
        /// Updates existing category or inserts a new category.
        /// </summary>
        /// <remarks>Use id of exsting category to update it. Or NULL to create a new category.</remarks>
        /// <param name="command">Upsert category command.</param>
        /// <returns>Id of created/updated category.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> Upsert([Required]UpsertCategoryCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        /// <summary>
        /// Delete category by id.
        /// </summary>
        /// <param name="id">Id of deleting category.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCategoryCommand { Id = id });

            return NoContent();
        }
    }
}
