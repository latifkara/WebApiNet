using FluentValidation;
using System;
namespace WebApiNet.BookOperations.GetBookDetail
{
    public class GetBookCommandValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookCommandValidator()
        {
           RuleFor(command=> command.BookId).GreaterThan(0);
        }
    }
}
