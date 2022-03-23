using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Models.DB.Tables;
using UnitTest.Infrastructures;
using Xunit;

namespace UnitTest.Tests
{
    public class DatabaseSampleTest : DBTestBase
    {
        [Fact]
        public async void GetSamplesTest()
        {
            (await dataContext.Samples.ToArrayAsync()).Should().BeEmpty();
        }

        [Fact]
        public async void GetSamplesTest_Insert()
        {
            await dataContext.Samples.AddRangeAsync(new Sample[]
            {
                new (){ Data = "データ1" },
                new (){ Data = "データ2" },
            });
            await dataContext.SaveChangesAsync();

            (await dataContext.Samples.ToArrayAsync()).Should().BeEquivalentTo(new Sample[]
            {
                new (){ ID = 1, Data = "データ1" },
                new (){ ID = 2, Data = "データ2" },
            });
        }
    }
}