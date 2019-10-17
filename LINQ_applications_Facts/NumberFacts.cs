using LINQ_applications;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LINQ_applications_Facts
{
    public class NumberFacts
    {
        [Fact]
        public void Test_GenerateSubsets_Longer_Collection()
        {
            //Given
            int[] array = { 1, 2, 3, 5, 4 };

            IEnumerable<IEnumerable<int>> result = new[] {
                new int[] { 4 }, new int[] { 1 }, new int[] { 2 },
                new int[] { 3 }, new int[] { 1, 2 }, new int[] {1, 3 }
            };
            //When
            var subSets = NumberOperations.GenerateSubsets(array, 4).Distinct();
            //Then
            Assert.Empty(subSets.Except(result));
        }

        [Fact]
        public void Test_GenerateSubsets_No_SubSet_Should_Be_Found()
        {
            //Given
            int[] array = { 5, 10 };
            //When
            var subSets = NumberOperations.GenerateSubsets(array, 3);
            //Then
            Assert.Empty(subSets);
        }

        [Fact]
        public void Test_GenerateSubsets_Simple_Case()
        {
            //Given
            int[] array = { 1, 2 };
            //When
            var subSets = NumberOperations.GenerateSubsets(array, 1);
            //Then
            Assert.Equal(new[] { new int[] { 1 } }, subSets);
        }
    }
}