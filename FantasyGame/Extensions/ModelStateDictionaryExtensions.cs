using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FantasyGame.Extensions;

/// <summary>
///     Extensions class for <see cref="ModelStateDictionary"/> class
/// </summary>
public static class ModelStateDictionaryExtensions
{
    /// <summary>
    ///     Extension method that gets string of <see cref="ModelStateDictionary"/> errors separated by <see cref="Environment.NewLine"/>
    /// </summary>
    /// <param name="modelState">
    ///     Extended object
    /// </param>
    /// <returns></returns>
    public static string GetErrors(this ModelStateDictionary modelState)
    {
        string result = string.Empty;
        List<string> values = modelState.Values
            .SelectMany(v => v.Errors)
            .Select(v => v.ErrorMessage)
            .ToList();
        values.ForEach(v => result += v + Environment.NewLine);
        return result.TrimEnd();
    }
}
