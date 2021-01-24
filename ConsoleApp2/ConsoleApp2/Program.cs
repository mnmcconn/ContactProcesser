using System;
using System.Collections.Generic;
using System.Diagnostics;
using ConsoleApp2.Models;
using System.Linq;
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Contact> contacts = Utility.GetData<Contact>(Properties.Settings.Default.ContactsURI);

            // Validate Contacts
            contacts.ForEach(s => s.Validate());

            // Step 1 
            contacts.OrderBy(c => c.FullName)
                .ToList().ForEach(s => Debug.WriteLine($"{s.FullName} - {s.Message}"));

            contacts.GroupBy(c => c.CityName, (key, g) => new
            {
                CityName = key,
                ErrCount = g.Sum(abc => abc.ErrorCount)
            }).OrderByDescending(c => c.ErrCount)
                .ToList().ForEach(s => Debug.WriteLine($"{s.CityName} - {s.ErrCount}"));
        }
    }
}
