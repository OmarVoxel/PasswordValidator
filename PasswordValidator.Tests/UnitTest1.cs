using System;
using Xunit;
using FluentAssertions;

namespace PasswordValidator.Tests
{
    public class PasswordShould
    {
        [Theory]
        [InlineData("1234", false, "Password must be at least 8 characters")] 
        [InlineData("123456", false, "Password must be at least 8 characters")]
        [InlineData("adssd", false, "Password must be at least 8 characters")]
        public void BeAtLeast8OrMoreCharacters(string pass, bool isValid, string message)
        {
            PasswordValidator password = new(pass);
            
            ValidationResult result = password.Validation();
            
            result.IsValid.Should().Be(isValid);
            result.Message.Should().Be(message);
        }
        
        
        [Theory]
        [InlineData("aaaaaaad2", false, "The password must contain at least 2 number")] 
        [InlineData("aaaaaaaaaaa", false, "The password must contain at least 2 number")]
        [InlineData("daaaaaaaada", false, "The password must contain at least 2 number")]
        public void ContainAtLeast2Numbers(string pass, bool isValid, string message)
        {
            PasswordValidator password = new(pass);
            
            ValidationResult result = password.Validation();
            
            result.IsValid.Should().Be(isValid);
            result.Message.Should().Be(message);
        }
        
        [Theory]
        [InlineData("aaaaaaad2", false, "Password must be at least 8 characters\nThe password must contain at least 2 numbers")] 
        [InlineData("aaaaaaaaaaa", false, "Password must be at least 8 characters\nThe password must contain at least 2 numbers")]
        public void BeAtLeast8OrMoreCharactersAndContainAtLeast2Numbers(string pass, bool isValid, string message)
        {
            PasswordValidator password = new(pass);
            
            ValidationResult result = password.Validation();
            
            result.IsValid.Should().Be(isValid);
            result.Message.Should().Be(message);
        }

        
        
    }
}