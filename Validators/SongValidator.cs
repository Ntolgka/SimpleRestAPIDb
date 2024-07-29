using Week2_Assesment.Models;

namespace Week2_Assesment.Validators;

using FluentValidation;
using FluentValidation.AspNetCore;
using Week2_Assesment.Models;

public class SongValidator : AbstractValidator<Song>
{
    public SongValidator()
    {
        RuleFor(Song => Song.Name).NotNull()
            .WithMessage("Song Name cannot be null.")
            .MaximumLength(50)
            .WithMessage("Song name must have a maximum of 50 characters.")
            .MinimumLength(1)
            .WithMessage("Song name must have a minimum of 1 character.");
        
        RuleFor(Song => Song.Band).NotNull()
            .WithMessage("Band cannot be null.")
            .MaximumLength(50)
            .WithMessage("Band must have a maximum of 50 characters.")
            .MinimumLength(1)
            .WithMessage("Band must have a minimum of 1 character.");

        RuleFor(Song => Song.Album)
            .MaximumLength(50)
            .WithMessage("Album of song must have a maximum of 50 characters.");

        RuleFor(Song => Song.ReleaseYear).NotNull()
            .WithMessage("Song's release date cannot be null.")
            .GreaterThanOrEqualTo(1700)
            .WithMessage("Song's release date must be greater than or equal to 1700")
            .LessThanOrEqualTo(2024)
            .WithMessage("Song's release date must be less than or equal to 2024");


    }
}