using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUser
{
    public class ListUserValidator : AbstractValidator<ListUserCommand>
    {
        /// <summary>
        /// Initializes validation rules for ListUserCommand
        /// </summary>
        public ListUserValidator()
        {
        }
    }
}
