using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApp.Application.Common.Models;
using SampleApp.Application.Users.Commands.CreateUser;
using SampleApp.Application.Users.Commands.DeleteUser;
using SampleApp.Application.Users.Commands.UpdateUser;
using SampleApp.Application.Users.Queries;
using SampleApp.Application.Users.Queries.GetUserById;
using SampleApp.Application.Users.Queries.GetUsersWithPagination;

namespace SampleApp.Server.Controllers
{
    public class UsersController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<UserDto>>> Get([FromQuery] GetUsersWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }
        [HttpGet("{id}")]
        public async Task<UserDto> GetById(int Id)
        {
            return await Mediator.Send(new GetUserByIdQuery(Id));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteUserCommand(id));

            return NoContent();
        }
    }
}
