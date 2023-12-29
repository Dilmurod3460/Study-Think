using Newtonsoft.Json;
using StudyThink.Service.Common.CustomAttributes.PhoneAttribute.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace StudyThink.Service.Common.CustomAttributes.PhoneAttributes
{
    public class PhoneNumberAttribute : ValidationAttribute
    {
        public List<Countries> GetAllCountries()
        {
            string path = @"D:\\Study-Think\\src\\StudyThink.Service\\Common\\CustomAttributes\\PhoneAttributes\\Json\\PhoneNumberAttributeJson.json\\";

            string jsonData = File.ReadAllText(path);

            List<Countries>? countries = JsonConvert.DeserializeObject<List<Countries>>(jsonData);

            return countries;
        }

        public override bool IsValid(object? value)
        {
            if (value == null)
                return false;

            string phoneNumber = value.ToString();

            foreach (var i in GetAllCountries())
            {
                string number = i.CountryPhoneNumberCode.ToString() + i.PhoneNumberLength.ToString();

                if (Regex.IsMatch(phoneNumber, $@"^\+\d{number.Count()}$"))
                    return true;
            }
            return false;

        }
    }
}
