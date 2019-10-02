using LINQ_applications;
using System;
using Xunit;

namespace LINQ_applications_Facts
{
    public class StringFactsFacts
    {
        [Fact]
        public void Test_VOCALS_Counter_Should_correctly_count_vocals_WORD_has_ONE_char()
        {
            //Given, When
            int count = StringOperations.CountVocals("a");
            //Then
            Assert.Equal(1, count);
        }

        [Fact]
        public void Test_VOCALS_Counter_Should_correctly_count_vocals_WORD_has_Only_Vocals()
        {
            //Given, When
            int count = StringOperations.CountVocals("aei");
            //Then
            Assert.Equal(3, count);
        }

        [Fact]
        public void Test_VOCALS_Counter_Should_count_vocals_WORD_has_Vocals_AND_Consonants()
        {
            //Given, When
            int count = StringOperations.CountVocals("abe");
            //Then
            Assert.Equal(2, count);
        }

        [Fact]
        public void Test_VOCALS_Counter_Should_Correctly_Work_for_Upper_Case()
        {
            //Given, When
            int count = StringOperations.CountVocals("AandDrEei");
            //Then
            Assert.Equal(5, count);
        }

        [Fact]
        public void Test_Consonants_Counter_Should_Correctly_Count_Consonants_from_inputString()
        {
            //Given, When
            int count = StringOperations.CountConsonants("AandDrEei");
            //Then
            Assert.Equal(4, count);
        }

        [Fact]
        public void Test_Consonants_Should_return_Zero_String_has_NO_Consonants()
        {
            //Given, When
            int count = StringOperations.CountConsonants("AeEiou");
            //Then
            Assert.Equal(0, count);
        }

        [Fact]
        public void Test_Vocals_Should_Throw_Exception_When_String_is_NULL()
        {
            //Given, When
            Action exception = () => StringOperations.CountVocals(null);
            //Then
            Assert.Throws<ArgumentNullException>(exception);
        }

        [Fact]
        public void Test_Consonants_Should_Throw_Exception_When_String_is_NULL()
        {
            //Given, When
            Action exception = () => StringOperations.CountConsonants(null);
            //Then
            Assert.Throws<ArgumentNullException>(exception);
        }

        [Fact]
        public void Test_UniqueChar_Should_Return_first_char_ONE_letter()
        {
            //Given, When
            char letter = StringOperations.FirstUniqueCharacter("a");
            //Then
            Assert.Equal('a', letter);
        }

        [Fact]
        public void Test_UniqueChar_Should_Return_correctly_For_More_COMPLEX_Word()
        {
            //Given, When
            char letter = StringOperations.FirstUniqueCharacter("aabcd");
            //Then
            Assert.Equal('b', letter);
        }
    }
}
