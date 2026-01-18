using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Soenneker.Dtos.MinMax;

namespace Soenneker.Extensions.Dictionaries.IntMinMax;

/// <summary>
/// A collection of helpful Dictionary int, MinMax extension methods
/// </summary>
public static class DictionaryIntMinMaxExtension
{
    // If MinMax is a class, this avoids repeated allocations for the empty case.
    private static readonly MinMax _zero = new() { Min = 0, Max = 0 };

    /// <summary>
    /// Computes the average <see cref="MinMax.Min"/> and <see cref="MinMax.Max"/> across all values in the dictionary.
    /// </summary>
    /// <param name="value">The dictionary containing <see cref="MinMax"/> values keyed by <see cref="int"/>.</param>
    /// <param name="roundingDigits">Optional number of decimal digits to round the averaged values to.</param>
    /// <returns>
    /// A <see cref="MinMax"/> containing the averaged <c>Min</c> and <c>Max</c>.
    /// Returns <c>Min = 0</c> and <c>Max = 0</c> when the dictionary is <c>null</c> or empty.
    /// </returns>
    [Pure]
    public static MinMax ToAverageMinMax(this Dictionary<int, MinMax>? value, int? roundingDigits = null)
    {
        if (value is null || value.Count == 0)
            return _zero;

        decimal min = 0m;
        decimal max = 0m;

        // Iterate values only (keys unused)
        foreach (MinMax mm in value.Values)
        {
            min += mm.Min;
            max += mm.Max;
        }

        int count = value.Count;

        min /= count;
        max /= count;

        if (roundingDigits.HasValue)
        {
            int digits = roundingDigits.GetValueOrDefault();
            min = Math.Round(min, digits);
            max = Math.Round(max, digits);
        }

        return new MinMax { Min = min, Max = max };
    }
}
