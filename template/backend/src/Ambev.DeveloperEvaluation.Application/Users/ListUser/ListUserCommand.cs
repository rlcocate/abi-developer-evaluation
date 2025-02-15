using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUser
{
    public record ListUserCommand : IRequest<List<ListUserResult>>
    {

    }
}
