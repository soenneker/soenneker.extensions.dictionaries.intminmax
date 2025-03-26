using Soenneker.Dtos.MinMax;
using Soenneker.Tests.Unit;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Soenneker.Extensions.Dictionaries.IntMinMax.Tests;

public sealed class DictionaryIntMinMaxExtensionTests : UnitTest
{
    [Fact]
    public void Default()
    {

    }

    [Fact]
    public void ToAverageMinMax_with_one_should_be_equal_to_max()
    {
        var minMaxDict = AutoFaker.Generate<Dictionary<int, MinMax>>();

        MinMax minMaxAvg = minMaxDict.ToAverageMinMax();

        minMaxAvg.Max.Should().Be(minMaxDict.First().Value.Max);
    }

    [Fact]
    public void ToAverageMinMax_with_three_should_average()
    {
        var minMaxDict = new Dictionary<int, MinMax>
        {
            {Faker.Random.Int(), AutoFaker.Generate<MinMax>()},
            {Faker.Random.Int(), AutoFaker.Generate<MinMax>()},
            {Faker.Random.Int(), AutoFaker.Generate<MinMax>()}
        };

        decimal averageMax = 0;
        decimal averageMin = 0;

        foreach (KeyValuePair<int, MinMax> kvp in minMaxDict)
        {
            averageMax += kvp.Value.Max;
            averageMin += kvp.Value.Min;
        }

        averageMax /= 3;
        averageMin /= 3;

        MinMax minMaxAvg = minMaxDict.ToAverageMinMax();

        minMaxAvg.Max.Should().Be(averageMax);
        minMaxAvg.Min.Should().Be(averageMin);
    }
}
