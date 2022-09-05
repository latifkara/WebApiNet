using FluentValidation;
using System;

namespace WebApiNet.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command=> command.BookId).GreaterThan(0);
            RuleFor(command=> command.up_Model.Title).NotEmpty().MinimumLength(4);
            RuleFor(command=> command.up_Model.GenreId).GreaterThan(0);
        }
    }
}