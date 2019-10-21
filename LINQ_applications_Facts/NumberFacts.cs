using LINQ_applications;
using System;
using System.Collections.Generic;
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
            //When
            IEnumerable<IEnumerable<int>> enumerable = NumberOperations.GenerateSubsets(array, 4);
            //Then
            Assert.Equal(new[]
            { new int[] { 1, 2 }, new int[] { 1 },
                new int[] { 2 }, new int[] { 3 }, new int[] { 4 } }
            , enumerable);
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

        [Fact]
        public void Test_PythagoreanNumbers_Array_Has_3_elements()
        {
            //Given
            int[] array = { 3, 4, 5 };
            //When
            var subSets = NumberOperations.GetPythagoreanNumbers(array);
            //Then
            Assert.Equal(new[] { new[] { 3, 4, 5 }, new[] { 4, 3, 5 } }, subSets);
        }

        [Fact]
        public void Test_PythagoreanNumbers_Should_Return_Empty_Enumerable_for_ShortArray()
        {
            //Given
            int[] array = { 1, 2 };
            //When
            var subSets = NumberOperations.GetPythagoreanNumbers(array);
            //Then
            Assert.Empty(subSets);
        }

        [Fact]
        public void Test_PythagoreanNumbers_for_Longer_Array()
        {
            //Given
            int[] array = { 1, 2, 3, 4, 5 };
            //When
            var subSets = NumberOperations.GetPythagoreanNumbers(array);
            //Then
            Assert.Equal(new[] { new[] { 3, 4, 5 }, new[] { 4, 3, 5 } }, subSets);
        }

        [Fact]
        public void Test_PythagoreanNumbers_Check_That_AllCombinations_are_Checked()
        {
            //Given
            int[] array = { 3, 1, 5, 4 };
            //When
            var subSets = NumberOperations.GetPythagoreanNumbers(array);
            //Then
            Assert.Equal(new[] { new[] { 3, 4, 5 }, new[] { 4, 3, 5 } }, subSets);
        }

        [Fact]
        public void Test_PythagoreanNumbers_When_Array_Has_Repeating_Elements()
        {
            //Given
            int[] array = { 0, 0, 0 };
            //When
            var subSets = NumberOperations.GetPythagoreanNumbers(array);
            //Then
            Assert.Equal(new[] { new[] { 0, 0, 0 } }, subSets);
        }

        [Fact]
        public void Test_PythagoreanNumbers_FinalTest()
        {
            //Given
            int[] array = {1, 2, 3, 4, 5, 12, 13 };
            //When
            var subSets = NumberOperations.GetPythagoreanNumbers(array);
            //Then
            Assert.Equal(new[] { new[] { 3, 4, 5 }, new[] { 4, 3, 5 },
                                new[] { 5, 12, 13 }, new[] { 12, 5, 13 } }
                         , subSets);
        }

        [Fact]
        public void Test_SumCombinations_For_Simple_Case()
        {
            //Given
            var tuple = Tuple.Create(2, 3);
            //When
            var combinations = NumberOperations.GetSumCombinations(tuple.Item1, tuple.Item2);
            //Then
            Assert.Equal(new[] { "1 + 2 = 3" }, combinations);
        }
    }
}