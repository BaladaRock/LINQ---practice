using LINQ_applications;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LINQ_applications_Facts
{
    public class MostUsedFacts
    {
        [Fact]
        public void Should_Return_one_Result_text_Contains_ONE_word()
        {
            //Given
            string[] text = new[] { "Ana", "Ana", "Ana" };
            //When
            var wordsApparitions = new WordsApparitions(text);
            IEnumerable<string> top = wordsApparitions.GetMostUsed();
            //Then
            Assert.Equal(new[] { "ana" }, top);
        }

        [Fact]
        public void Should_Return_Top_Text_Contains_MORE_words()
        {
            //Given
            string[] text = new[] { "ana", "are", "are", "mere" };
            //When
            var wordsApparitions = new WordsApparitions(text);
            IEnumerable<string> top = wordsApparitions.GetMostUsed();
            //Then
            Assert.Equal(new[] { "are", "ana", "mere" }, top);
        }

        [Fact]
        public void Should_Return_Top_Text_More_Complex_Text()
        {
            //Given
            string[] text = new[] { "Ana", "are", "are", "mere", "B", "b", "b" };
            //When
            var wordsApparitions = new WordsApparitions(text);
            IEnumerable<string> top = wordsApparitions.GetMostUsed();
            //Then
            Assert.Equal(new[] { "b", "are", "ana", "mere" }, top);
        }
    }
}
