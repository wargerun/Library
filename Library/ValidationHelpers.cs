using System.Collections.Generic;
using System.Data.Entity.Validation;

namespace Library
{
    public class ValidationHelpers
    {
        public static string GetValidationErrors(DbEntityValidationException validationError)
        {
            List<string> errors = new List<string>();

            foreach (var validationResults in validationError.EntityValidationErrors)
            {
                foreach (var error in validationResults.ValidationErrors)
                {
                    errors.Add($"Поле: {error.PropertyName} - {error.ErrorMessage}");
                }
            }

            return string.Join("\n", errors);
        }
    }
}