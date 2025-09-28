using System.ComponentModel.DataAnnotations;

namespace hw2709.Models
{
    public class NotFutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateValue)
            {
                return dateValue <= DateTime.Now;
            }
            return false;
        }
    }
}
