using LINQ_applications;
using System.Collections.Generic;
using Xunit;

namespace LINQ_applications_Facts
{
    public class MostApparitions
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
            Assert.Equal(new[] { "\"ana\" - 3" }, top);
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
            Assert.Equal(new[] { "\"are\" - 2", "\"ana\" - 1", "\"mere\" - 1" }, top);
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
            Assert.Equal(new[] { "\"b\" - 3", "\"are\" - 2", "\"ana\" - 1", "\"mere\" - 1" }, top);
        }
    }
}