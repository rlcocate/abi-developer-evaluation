using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUser
{
    public class ListUserHandler : IRequestHandler<ListUserCommand, List<ListUserResult>>
    {
        private readonly IListUserRepository _listUserRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of ListUserHandler
        /// </summary>
        /// <param name="listUserRepository">The list user repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public ListUserHandler(IListUserRepository listUserRepository, IMapper mapper)
        {
            _listUserRepository = listUserRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the ListUserCommand request
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A list of user details if found</returns>
        public async Task<List<ListUserResult>> Handle(ListUserCommand request, CancellationToken cancellationToken)
        {
            var users = await _listUserRepository.ListAsync(cancellationToken);
            if (!users.Any())
                throw new KeyNotFoundException($"List of users not found");
            return _mapper.Map<List<ListUserResult>>(users);
        }
    }

}
