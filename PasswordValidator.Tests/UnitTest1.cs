using Xunit;
using FluentAssertions;

namespace PasswordValidator.Tests
{
    public class PasswordShould
    {
        [Theory]
        [InlineData("#23A", false, "Password must be at least 8 characters")] 
        [InlineData("1#34S6", false, "Password must be at least 8 characters")]
        [InlineData("s1D#3sd", false, "Password must be at least 8 characters")]
        public void BeAtLeast8OrMoreCharacters(string pass, bool isValid, string message)
        {
            PasswordValidator password = new(pass);
            
            ValidationResult result = password.Validation();
            
            result.IsValid.Should().Be(isValid);
            result.Message.Should().Be(message);
        }
        
        
        [Theory]
        [InlineData("aaaSaaa-d2", false, "The password must contain at least 2 numbers")] 
        [InlineData("aaaaSa&aaaaaa", false, "The password must contain at least 2 numbers")]
        [InlineData("daaaa&AAaaaada", false, "The password must contain at least 2 numbers")]
        public void ContainAtLeast2Numbers(string pass, bool isValid, string message)
        {
            PasswordValidator password = new(pass);
            
            ValidationResult result = password.Validation();
            
            result.IsValid.Should().Be(isValid);
            result.Message.Should().Be(message);
        }
        
        [Theory]
        [InlineData("aa&dS2", false, "Password must be at least 8 characters\nThe password must contain at least 2 numbers")] 
        [InlineData("ss&S2", false, "Password must be at least 8 characters\nThe password must contain at least 2 numbers")]
        public void BeAtLeast8OrMoreCharactersAndContainAtLeast2Numbers(string pass, bool isValid, string message)
        {
            PasswordValidator password = new(pass);
            
            ValidationResult result = password.Validation();
            
            result.IsValid.Should().Be(isValid);
            result.Message.Should().Be(message);
        }
        
        [Theory]
        [InlineData("aa*aaaad32", false, "The password must contain at least one capital letter")] 
        [InlineData("aa!aaaaaa22aa", false, "The password must contain at least one capital letter")]
        [InlineData("da!aaaaaa33da", false, "The password must contain at least one capital letter")]
        public void ContainAtLeastOneCapitalLetter(string pass, bool isValid, string message)
        {
            PasswordValidator password = new(pass);
            
            ValidationResult result = password.Validation();
            
            result.IsValid.Should().Be(isValid);
            result.Message.Should().Be(message);
        }
        
        [Theory]
        [InlineData("aaaaaaSd32", false, "The password must contain at least one special character")] 
        [InlineData("aaaaSaaaa22aa", false, "The password must contain at least one special character")]
        [InlineData("daaaaaaSa33da", false, "The password must contain at least one special character")]
        public void ContainAtLeastOneSpecialCharacter(string pass, bool isValid, string message)
        {
            PasswordValidator password = new(pass);
            
            ValidationResult result = password.Validation();
            
            result.IsValid.Should().Be(isValid);
            result.Message.Should().Be(message);
        }
    }
}