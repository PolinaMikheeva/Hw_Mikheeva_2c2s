using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Features.Games.Queries;
using TeamHost.Domain.Entities;
using TeamHost.Persistence.Contexts;

namespace TeamHost.Web.Areas.GameProfile.Controllers
{
    [Area("GameProfile")]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetGameQuery(id));
            return View(result);
        }
    }
}
