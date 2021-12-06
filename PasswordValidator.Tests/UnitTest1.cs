using System;
using Xunit;
using FluentAssertions;

namespace PasswordValidator.Tests
{
    public class PasswordShould
    {
        [Theory]
        [InlineData("123A", false, "Password must be at least 8 characters")] 
        [InlineData("1234S6", false, "Password must be at least 8 characters")]
        [InlineData("as1D3sd", false, "Password must be at least 8 characters")]
        public void BeAtLeast8OrMoreCharacters(string pass, bool isValid, string message)
        {
            PasswordValidator password = new(pass);
            
            ValidationResult result = password.Validation();
            
            result.IsValid.Should().Be(isValid);
            result.Message.Should().Be(message);
        }
        
        
        [Theory]
        [InlineData("aaaSaaad2", false, "The password must contain at least 2 numbers")] 
        [InlineData("aaaaSaaaaaaa", false, "The password must contain at least 2 numbers")]
        [InlineData("daaaaAAaaaada", false, "The password must contain at least 2 numbers")]
        public void ContainAtLeast2Numbers(string pass, bool isValid, string message)
        {
            PasswordValidator password = new(pass);
            
            ValidationResult result = password.Validation();
            
            result.IsValid.Should().Be(isValid);
            result.Message.Should().Be(message);
        }
        
        [Theory]
        [InlineData("aadS2", false, "Password must be at least 8 characters\nThe password must contain at least 2 numbers")] 
        [InlineData("ssS2", false, "Password must be at least 8 characters\nThe password must contain at least 2 numbers")]
        public void BeAtLeast8OrMoreCharactersAndContainAtLeast2Numbers(string pass, bool isValid, string message)
        {
            PasswordValidator password = new(pass);
            
            ValidationResult result = password.Validation();
            
            result.IsValid.Should().Be(isValid);
            result.Message.Should().Be(message);
        }
        
        [Theory]
        [InlineData("aaaaaad32", false, "The password must contain at least one capital letter")] 
        [InlineData("aaaaaaaa22aa", false, "The password must contain at least one capital letter")]
        [InlineData("daaaaaaa33da", false, "The password must contain at least one capital letter")]
        public void ContainAtLeastOneCapitalLetter(string pass, bool isValid, string message)
        {
            PasswordValidator password = new(pass);
            
            ValidationResult result = password.Validation();
            
            result.IsValid.Should().Be(isValid);
            result.Message.Should().Be(message);
        }
    }
}