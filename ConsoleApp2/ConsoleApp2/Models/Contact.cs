using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Models
{
    public class Contact
    {
        public string FullName { get; set; }
        public string CityName { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsValidPhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool IsValidEmailAddress { get; set; }

        public string Message
        {
            get
            {
                if (IsValidPhoneNumber && IsValidEmailAddress)
                {
                    return "Valid";
                }
                else if (IsValidEmailAddress && !IsValidPhoneNumber)
                {
                    return "Phone is invalid.";
                }
                else if (!IsValidEmailAddress && IsValidPhoneNumber)
                {
                    return "Email is invalid.";
                }
                else
                {
                    return "Email and Phone are invalid.";
                }
            }
        }

        public int ErrorCount => (IsValidEmailAddress ? 0 : 1) + (IsValidPhoneNumber ? 0 : 1);


        public void Validate()
        {
            IsValidEmailAddress = Utility.isValidEmail(EmailAddress);
            IsValidPhoneNumber = Utility.isValidPhone(PhoneNumber);           
        }
    }
}