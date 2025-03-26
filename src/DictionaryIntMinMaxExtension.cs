using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Soenneker.Dtos.MinMax;
using Soenneker.Extensions.Enumerable;

namespace Soenneker.Extensions.Dictionaries.IntMinMax;

/// <summary>
/// A collection of helpful Dictionary int, MinMax extension methods
/// </summary>
public static class DictionaryIntMinMaxExtension
{
    /// <summary>
    /// Calculates the average minimum and maximum values from a dictionary of <see cref="MinMax"/> values,
    /// optionally rounding the result to the specified number of digits.
    /// </summary>
    /// <param name="value">The dictionary containing <see cref="MinMax"/> values keyed by <see cref="int"/>.</param>
    /// <param name="roundingDigits">The number of digits to round the average values to, or <c>null</c> to skip rounding.</param>
    /// <returns>
    /// A <see cref="MinMax"/> instance containing the averaged <c>Min</c> and <c>Max</c> values. 
    /// Returns <c>Min = 0</c> and <c>Max = 0</c> if the dictionary is <c>null</c> or empty.
    /// </returns>
    [Pure]
    public static MinMax ToAverageMinMax(this Dictionary<int, MinMax> value, int? roundingDigits = null)
    {
        if (value.IsNullOrEmpty())
            return new MinMax { Min = 0, Max = 0 };

        decimal min = 0, max = 0;

        foreach (KeyValuePair<int, MinMax> kvp in value)
        {
            min += kvp.Value.Min;
            max += kvp.Value.Max;
        }

        min /= value.Count;
        max /= value.Count;

        if (roundingDigits != null)
        {
            min = Math.Round(min, roundingDigits.Value);
            max = Math.Round(max, roundingDigits.Value);
        }

        return new MinMax { Max = max, Min = min };
    }
}
