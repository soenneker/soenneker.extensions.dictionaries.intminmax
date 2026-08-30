[![](https://img.shields.io/nuget/v/soenneker.extensions.dictionaries.intminmax.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.dictionaries.intminmax/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.dictionaries.intminmax/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.dictionaries.intminmax/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.dictionaries.intminmax.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.dictionaries.intminmax/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.dictionaries.intminmax/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.dictionaries.intminmax/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.Dictionaries.IntMinMax
Extension methods for aggregating and transforming dictionaries whose integer keys map to `MinMax` ranges.

## Installation

```bash
dotnet add package Soenneker.Extensions.Dictionaries.IntMinMax
```

## Usage

```csharp
using Soenneker.Extensions.Dictionaries.IntMinMax;

var readings = new Dictionary<int, MinMax>
{
    [1] = new() { Min = 10m, Max = 20m },
    [2] = new() { Min = 14m, Max = 30m }
};

MinMax average = readings.ToAverageMinMax();
// average.Min = 12m
// average.Max = 25m
```

`ToAverageMinMax(roundingDigits)` optionally rounds both averages with `Math.Round`. A null or empty dictionary returns a new `MinMax` with `Min = 0` and `Max = 0`; it does not return `null`, throw, or share a mutable fallback instance between calls.
