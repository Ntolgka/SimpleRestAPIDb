using Week2_Assignment.Models;
using FluentValidation;

namespace Week2_Assignment.Validators;

public class SongValidator : AbstractValidator<Song>
{
    public SongValidator()
    {
        RuleFor(song => song.Name).NotEmpty()
            .WithMessage("Song Name cannot be null.")
            .Length(1, 50)
            .WithMessage("Song name must have a maximum of 50 and a minimum of 1 characters.");

        RuleFor(song => song.Band).NotEmpty()
            .WithMessage("Band cannot be null.")
            .Length(1, 50)
            .WithMessage("Band must have a maximum of 50 and a minimum of 1 characters.");

        RuleFor(song => song.Album)
            .MaximumLength(50)
            .WithMessage("Album of song must have a maximum of 50 characters.");

        RuleFor(song => song.ReleaseYear).NotEmpty()
            .WithMessage("Song's release date cannot be null.")
            .GreaterThanOrEqualTo(1700)
            .WithMessage("Song's release date must be greater than or equal to 1700")
            .LessThanOrEqualTo(2024)
            .WithMessage("Song's release date must be less than or equal to 2024");
    }
    
    
}