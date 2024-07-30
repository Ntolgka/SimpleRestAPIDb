using Week2_Assignment.Models;

namespace Week2_Assignment.Extensions;

public static class SongExtensions
{
    //This extension will return if a song is a classic or not.
    public static bool IsClassic(this Song song)
    {
        const int classicThresholdYear = 1990;
        return song.ReleaseYear < classicThresholdYear;
    }
}