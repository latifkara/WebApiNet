using FluentValidation;
using System;
namespace WebApiNet.BookOperations.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command=> command.BookId).GreaterThan(0);
        }
    }
}