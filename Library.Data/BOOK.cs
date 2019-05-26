using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Data
{
    public class BOOK
    {
        public BOOK()
        {
            this.COUNT = 0;
        }

        public decimal ID { get; set; }

        [Required]
        public string ISBN { get; set; }
        [Required]
        public string NAME { get; set; }

        public string AUTHOR { get; set; }

        public string PUBLISHING { get; set; }

        [CustomValidation(typeof(NumberValueValidationAttribute), "PositiveValue")]
        public int? COUNT { get; set; }

        public string STATUS { get; set; }

        public string DESCRIPTION { get; set; }

        [CustomValidation(typeof(NumberValueValidationAttribute), "PositiveValue"), Required]
        public decimal PRICE { get; set; }

        public virtual ICollection<BOOKS_ISSUED> BOOKS_ISSUED { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class NumberValueValidationAttribute : ValidationAttribute
    {
        public static ValidationResult PositiveValue(int value)
        {
            if (value > 0)
                return ValidationResult.Success;
            else
                return new ValidationResult("Значение не может быть отрицательным");
        }
    }
}
