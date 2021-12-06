﻿using System;
using System.Linq;

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
            if (_password.Length < 8)
                return NotValidPassword("Password must be at least 8 characters");

            if (_password.Count(char.IsDigit) < 2)
                return NotValidPassword("The password must contain at least 2 number");

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