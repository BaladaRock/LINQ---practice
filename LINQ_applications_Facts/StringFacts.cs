using LINQ_applications;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LINQ_applications_Facts
{
    public class StringFactsFacts
    {
        [Fact]
        public void Test_ConvertToInt_Should_Throw_exception_String_contains_Digits_and_is_NOT_Number()
        {
            //Given, When
            Action conversion = () => StringOperations.ConvertStringToInt("1a");
            //Then
            Assert.Throws<FormatException>(conversion);
        }

        [Fact]
        public void Test_ConvertToInt_Should_Throw_Exception_String_is_NOT_int()
        {
            //Given, When
            Action exception = () => StringOperations.ConvertStringToInt("abc");
            //Then
            Assert.Throws<FormatException>(exception);
        }

        [Fact]
        public void Test_ConvertToInt_Should_work_correctly_when_string_is_Digit()
        {
            //Given, When
            int conversion = StringOperations.ConvertStringToInt("1");
            //Then
            Assert.Equal(1, conversion);
        }

        [Fact]
        public void Test_ConvertToInt_Should_work_correctly_when_string_is_Number()
        {
            //Given, When
            int conversion = StringOperations.ConvertStringToInt("123");
            //Then
            Assert.Equal(123, conversion);
        }

        [Fact]
        public void Test_ConvertToInt_String_is_Number_and_has_More_Leading_Whitespaces()
        {
            //Given, When
            int conversion = StringOperations.ConvertStringToInt("   123");
            //Then
            Assert.Equal(123, conversion);
        }

        [Fact]
        public void Test_ConvertToInt_String_is_Number_and_has_SIGN()
        {
            //Given, When
            int conversion = StringOperations.ConvertStringToInt("+123");
            //Then
            Assert.Equal(123, conversion);
        }

        [Fact]
        public void Test_ConvertToInt_String_is_Number_and_has_WhiteSpacesAndSign()
        {
            //Given, When
            int conversion = StringOperations.ConvertStringToInt(" -123");
            //Then
            Assert.Equal(123, conversion);
        }

        [Fact]
        public void Test_ConvertToInt_String_is_Number_and_has_WhiteSpacesAtTheBeginning()
        {
            //Given, When
            int conversion = StringOperations.ConvertStringToInt(" 123");
            //Then
            Assert.Equal(123, conversion);
        }

        [Fact]
        public void Test_ConvertToInt_String_is_Number_and_has_WhiteSpacesAtTheEnd()
        {
            //Given, When
            int conversion = StringOperations.ConvertStringToInt("123 ");
            //Then
            Assert.Equal(123, conversion);
        }

        [Fact]
        public void Test_Counter_Should_Correctly_Count_Vocals_for_Upper_Case()
        {
            //Given, When
            (int, int) count = StringOperations.VocalsAndConsonants("AandDrEei");
            //Then
            Assert.Equal((5, 4), count);
        }

        [Fact]
        public void Test_Counter_should_correctly_count_VOCALS_word_has_ONE_char()
        {
            //Given, When
            (int, int) count = StringOperations.VocalsAndConsonants("a");
            //Then
            Assert.Equal((1, 0), count);
        }

        [Fact]
        public void Test_Counter_Should_correctly_count_vocals_WORD_has_Only_Vocals()
        {
            //Given, When
            (int, int) count = StringOperations.VocalsAndConsonants("aei");
            //Then
            Assert.Equal((3, 0), count);
        }

        [Fact]
        public void Test_Counter_Should_count_vocals_WORD_has_Vocals_AND_Consonants()
        {
            //Given, When
            (int, int) count = StringOperations.VocalsAndConsonants("abe");
            //Then
            Assert.Equal((2, 1), count);
        }

        [Fact]
        public void Test_Counter_Should_return_Zero_String_has_NO_Consonants()
        {
            //Given, When
            (int, int) count = StringOperations.VocalsAndConsonants("AeEiou");
            //Then
            Assert.Equal((6, 0), count);
        }

        [Fact]
        public void Test_Counter_Should_Throw_Exception_When_String_is_NULL()
        {
            //Given, When
            Action exception = () => StringOperations.VocalsAndConsonants(null);
            //Then
            Assert.Throws<ArgumentNullException>(exception);
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
        public void Test_MostAparitions_Should_Throw_Exception_For_Empty_String()
        {
            //Given, When
            Action exception = () => StringOperations.MostAparitionsChar(string.Empty);
            //Then
            Assert.Throws<InvalidOperationException>(exception);
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
            //Given
            IEnumerable<string> enumerable = new[] { "a", "b", "c" };
            //When
            var palindroms = StringOperations.GeneratePalindroms("abc");
            //Then
            Assert.Empty(palindroms.Except(enumerable));
        }

        [Fact]
        public void Test_Palindroms_Longer_Word()
        {
            //Given
            IEnumerable<string> enumerable = new[] { "a","b", "c", "aa",
                                                "aaa", "aaaa", "aba", "aabaa" };
            // When
            var palindroms = StringOperations.GeneratePalindroms("aabaac").Distinct();
            //Then
            Assert.Empty(palindroms.Except(enumerable));
        }

        [Fact]
        public void Test_Palindroms_Longer_Word_One_Character()
        {
            //Given
            IEnumerable<string> enumerable = new[] { "a", "a", "a", "aa", "aa", "aa", "aaa" };
            // When
            var palindroms = StringOperations.GeneratePalindroms("aaa");
            //Then
            Assert.Empty(palindroms.Except(enumerable));
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
    }
}