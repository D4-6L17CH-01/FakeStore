using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MyCkRequired : ValidationAttribute
    {
        public int MaxLength { get; }

        public MyCkRequired(int maxLength = 528)
        {
            MaxLength = maxLength;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string val)
            {
                if (string.IsNullOrWhiteSpace(val))
                {
                    if (string.IsNullOrWhiteSpace(ErrorMessageString) || ErrorMessageString.Contains("The field"))
                        return new ValidationResult(GetErrorMessage(validationContext.MemberName));
                    else return new ValidationResult(ErrorMessageString);
                }


                if (val.Length > MaxLength)
                    return new ValidationResult($"El máximo tamaño del campo {validationContext.MemberName} es de {MaxLength}");
            }
            else if (value == null)
            {
                if (string.IsNullOrWhiteSpace(ErrorMessageString) || ErrorMessageString.Contains("The field"))
                    return new ValidationResult(GetErrorMessage(validationContext.MemberName));
                else return new ValidationResult(ErrorMessageString);
            }
            return ValidationResult.Success;
        }

        private string GetErrorMessage(string campo) => $"El campo {campo} es requerido";
    }
}
