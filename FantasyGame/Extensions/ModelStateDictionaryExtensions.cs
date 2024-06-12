using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FantasyGame.Extensions;

/// <summary>
///     Extensions class for <see cref="ModelStateDictionary"/> class
/// </summary>
public static class ModelStateDictionaryExtensions
{
    /// <summary>
    ///     Extension method that gets list of <see cref="ModelStateDictionary"/> errors.
    /// </summary>
    /// <param name="modelState">Extended object</param>
    /// <returns>A list of errors.</returns>
    public static List<string> GetErrors(this ModelStateDictionary modelState)
    {
        return modelState.Values
            .SelectMany(v => v.Errors)
            .Select(v => v.ErrorMessage)
            .ToList();
    }
}
