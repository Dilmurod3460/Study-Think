using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace StudyThink.Service.Common.CustomAttributes.EmailAttributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class EmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            string? email = value.ToString();

            if (Regex.IsMatch(email, @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$"))
                return true;
            return false;
        }
    }
}
