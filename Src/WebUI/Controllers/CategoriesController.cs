﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Categories.Queries.GetCategoriesList;

namespace Northwind.WebUI.Controllers
{
    [Authorize]
    public class CategoriesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IList<CategoryLookupModel>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetCategoriesListQuery()));
        }
    }
}
