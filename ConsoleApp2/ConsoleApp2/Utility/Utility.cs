using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    public static class Utility
    {
        public static List<T> GetData<T>(string resource)
        {
            string json = String.Empty;
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(resource))
            using (StreamReader reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<List<T>>(json);

        }
        //•	Phone field: is numeric with only digits, dashes, and spaces allowed 
        public static bool isValidPhone(string phoneNumber)
        {
            Regex regex = new Regex(@"^[0-9-\s]+$");
            
            Match match = regex.Match(phoneNumber);

            return match.Success;
        }
        //•	Email field: has exactly one @ symbol with data on each side
        public static bool isValidEmail(string email)
        {
            Regex regex = new Regex(@"[^@]@{1}[^@]");

            Match match = regex.Match(email);

            return match.Success;
        }
    }
}
