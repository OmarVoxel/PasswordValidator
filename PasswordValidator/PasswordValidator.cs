using System;

namespace PasswordValidator
{
    public class PasswordValidator
    {
        private readonly string _password;

        public PasswordValidator(string password)
        {   
            _password = password;
        }
        public ValidationResult Validation()
        {
            return new ValidationResult(true, null);
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