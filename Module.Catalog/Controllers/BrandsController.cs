using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Catalog.Core.Commands;
using Module.Catalog.Core.Queries;
using System.Threading.Tasks;

namespace Module.Catalog.Controllers
{
    [ApiController]
    [Route("/api/catalog/[controller]")]
    internal class BrandsController: ControllerBase
    {
        private readonly IMediator mediator;

        public BrandsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await mediator.Send(new GetAllBrandsQuery()));
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterBrandCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
