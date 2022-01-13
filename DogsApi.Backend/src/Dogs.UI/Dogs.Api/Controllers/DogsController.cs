using Dogs.Api.Common.Helpers;
using Dogs.Application.Dogs.Queries.GetDogsList;
using Dogs.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dogs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ping")]
        [ThrottleFilterAttribute(Name = "Throttle", Message = "You must wait {n} seconds before accessing this url again.", Seconds = 1)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<string> Ping()
        {
            return "Dogs House Service. Version 1.0.1";
        }

        [HttpGet("dogs")]
        [ThrottleFilterAttribute(Name = "Throttle", Message = "You must wait {n} seconds before accessing this url again.", Seconds = 1)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Dog[]> GetFriendList()
        {
            return await _mediator.Send(new GetDogsListQuery());
        }


        [HttpPost("dog")]
        [ThrottleFilterAttribute(Name = "Throttle", Message = "You must wait {n} seconds before accessing this url again.", Seconds = 1)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Guid> CreateFriend(Application.Dogs.Commands.CreateDog.CreateDogCommand cmd)
        {
            return await _mediator.Send(cmd);
        }

    }
}
