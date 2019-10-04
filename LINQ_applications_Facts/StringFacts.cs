using LINQ_applications;
using System;
using Xunit;

namespace LINQ_applications_Facts
{
    public class StringFactsFacts
    {
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
        public void Test_Consonants_Should_Throw_Exception_When_String_is_NULL()
        {
            //Given, When
            Action exception = () => StringOperations.CountConsonants(null);
            //Then
            Assert.Throws<ArgumentNullException>(exception);
        }

        [Fact]
        public void Test_ConvertToInt_Should_convert_longer_STRING_to_Int()
        {
            //Given, When
            int conversion = StringOperations.ConvertToInteger("abc");
            //Then
            Assert.Equal(294, conversion);
        }

        [Fact]
        public void Test_ConvertToInt_Should_Convert_single_CHAR_to_int()
        {
            //Given, When
            int conversion = StringOperations.ConvertToInteger("a");
            //Then
            Assert.Equal(97, conversion);
        }

        [Fact]
        public void Test_MostAparitions_Word_Has_More_Chars()
        {
            //Given, When
            char letter = StringOperations.MostAparitionsChar("dbbdcdada");
            //Then
            Assert.Equal('d', letter);
        }

        [Fact]
        public void Test_MostAparitions_Check_That_Order_is_Preserved()
        {
            //Given, When
            char letter = StringOperations.MostAparitionsChar("abccbd");
            //Then
            Assert.Equal('b', letter);
        }

        [Fact]
        public void Test_MostAparitions_Word_Has_Only_One_Char()
        {
            //Given, When
            char letter = StringOperations.MostAparitionsChar("aaaaaaa");
            //Then
            Assert.Equal('a', letter);
        }

        [Fact]
        public void Test_Palindroms_For_Simple_Word()
        {
            //Given, When
            var palindroms = StringOperations.GeneratePalindroms("aaa");
            //Then
            Assert.Equal(new[] { "a" }, palindroms);
        }

        [Fact]
        public void Test_UniqueChar_Should_Return_correctly_For_More_COMPLEX_Word()
        {
            //Given, When
            char letter = StringOperations.FirstUniqueCharacter("ababbbcd");
            //Then
            Assert.Equal('c', letter);
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
        public void Test_UniqueChar_Should_Return_Null_When_NO_Character_was_Found()
        {
            //Given, When
            Action exception = () => StringOperations.FirstUniqueCharacter("ababbbcc");
            //Then
            Assert.Throws<InvalidOperationException>(exception);
        }

        [Fact]
        public void Test_UniqueChar_Should_Return_Second_Letter()
        {
            //Given, When
            char letter = StringOperations.FirstUniqueCharacter("aabcd");
            //Then
            Assert.Equal('b', letter);
        }

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
        public void Test_VOCALS_Counter_Should_Correctly_Work_for_Upper_Case()
        {
            //Given, When
            int count = StringOperations.CountVocals("AandDrEei");
            //Then
            Assert.Equal(5, count);
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
        public void Test_Vocals_Should_Throw_Exception_When_String_is_NULL()
        {
            //Given, When
            Action exception = () => StringOperations.CountVocals(null);
            //Then
            Assert.Throws<ArgumentNullException>(exception);
        }
    }
}