using System;
using System.Collections.Generic;
using Xunit;
using LINQ_applications;

namespace LINQ_applications_Facts
{
    public class NumberFacts
    {
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
