using LINQ_applications;
using System.Collections.Generic;
using Xunit;

namespace LINQ_applications_Facts
{
    public class ResultsFacts
    {
        [Fact]
        public void Test_Results_List_contains_More_simple_families()
        {
            //Given

            var firstResult = new TestResults(id: "Ionescu", familyId: "I", score: 10);
            var secondResult = new TestResults(id: "Popescu", familyId: "P", score: 5);
            var thirdResult = new TestResults(id: "Ionescu", familyId: "I", score: 15);

            var list = new List<TestResults> { firstResult, secondResult, thirdResult };

            //When
            var resultsMaximum = new ResultsMaximum(list);
            var filteredList = resultsMaximum.GetMaxPerFamily();

            //Then
            Assert.Equal(new[] { thirdResult, secondResult }, filteredList);
        }

        [Fact]
        public void Test_Results_List_contains_More_simple_families_with_Duplicates()
        {
            //Given

            var firstResult = new TestResults(id: "Ionescu", familyId: "I", score: 10);
            var secondResult = new TestResults(id: "Popescu", familyId: "P", score: 5);
            var thirdResult = new TestResults(id: "Ionescu", familyId: "I", score: 15);
            var duplicate = new TestResults(id: "Ionescu", familyId: "I", score: 15);

            var list = new List<TestResults> { firstResult, secondResult, thirdResult, duplicate };

            //When
            var resultsMaximum = new ResultsMaximum(list);
            var filteredList = resultsMaximum.GetMaxPerFamily();

            //Then
            Assert.Equal(new[] { thirdResult, secondResult }, filteredList);
        }

        [Fact]
        public void Test_Results_List_contains_TWO_simple_families()
        {
            //Given

            var firstFamily = new TestResults(id: "Ionescu", familyId: "I", score: 10);
            var secondFamily = new TestResults(id: "Popescu", familyId: "P", score: 5);
            var list = new List<TestResults> { firstFamily, secondFamily };

            //When
            var resultsMaximum = new ResultsMaximum(list);
            var filteredList = resultsMaximum.GetMaxPerFamily();

            //Then
            Assert.Equal(new[] { firstFamily, secondFamily }, filteredList);
        }
    }
}