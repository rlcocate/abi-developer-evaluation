using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUser
{
    public class ListUserProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for ListUser operation
        /// </summary>
        public ListUserProfile()
        {
            CreateMap<User, ListUserResult>();
        }
    }
}
