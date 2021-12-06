using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PasswordValidator
{
    public class PasswordValidator
    {
        private readonly string _password;

        public PasswordValidator(string password)
            => _password = password;

        private ValidationResult CorrectPassword()
            => new ValidationResult(true, null);

        private ValidationResult NotValidPassword(string message)
            => new ValidationResult(false, message);
        
        public ValidationResult Validation()
        {
            List<string> message = new List<string>();
            
            Regex regexPassword = new Regex(@"^[a-zA-Z0-9 ]*$");

            if(regexPassword.IsMatch(_password))
                message.Add("The password must contain at least one special character");

            if(_password == _password.ToLower())
                message.Add("The password must contain at least one capital letter");
            
            if (_password.Length < 8)
                message.Add("Password must be at least 8 characters");

            if (_password.Count(char.IsDigit) < 2)
                message.Add("The password must contain at least 2 numbers");
            
            if (message.Any())
                return NotValidPassword(message.Aggregate((a,b) => a + "\n" + b));
            
            return CorrectPassword();
        }
    }

    public class ValidationResult
    {
        public string Message { get; }
        public bool IsValid { get; }

        public ValidationResult(bool isValid, string message)
        {
            IsValid = isValid;
            Message = message;
        }
        
    }
}