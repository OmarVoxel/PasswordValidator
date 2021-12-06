using System;
using Xunit;
using FluentAssertions;

namespace PasswordValidator.Tests
{
    public class PasswordShould
    {
        [Fact]
        public void BeAtLeast8OrMoreCharacters()
        {
            PasswordValidator password = new("12345");
            
            ValidationResult result = password.Validation();
            
            result.IsValid.Should().Be(false);
            result.Message.Should().Be("Password must be at least 8 characters");
        }
    }
}