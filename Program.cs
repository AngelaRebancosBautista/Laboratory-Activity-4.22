using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laboratory_Activity_22
{
    internal class Program
    {
        class Email
        {
            public string Address { get; private set; }
            public string Domain { get; private set; }
            public bool IsValid { get; private set; }

            public Email(string email)
            {
                Address = email.Trim().ToLower();
                IsValid = Regex.IsMatch(Address, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

                if (IsValid)
                {
                    Domain = Address.Split('@')[1];
                }
            }
        }
        static void Main()
        {
            Console.WriteLine("Enter emails separated by commas:");
            string input = Console.ReadLine();

            string[] parts = input.Split(',');
            List<string> invalid = new List<string>();
            Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();

            foreach (string p in parts)
            {
                Email e = new Email(p);

                if (e.IsValid)
                {
                    if (!groups.ContainsKey(e.Domain))
                        groups[e.Domain] = new List<string>();

                    groups[e.Domain].Add(e.Address);
                }
                else
                {
                    invalid.Add(p.Trim());
                }
            }
            Console.WriteLine("Email Groups");
            foreach (var domain in groups.Keys)
            {
                Console.WriteLine(domain + ":");
                foreach (var addr in groups[domain])
                    Console.WriteLine("  " + addr);
            }
            if (invalid.Count > 0)
            {
                Console.WriteLine("\nInvalid Emails:");
                foreach (var bad in invalid)
                    Console.WriteLine(bad);
            }
        }
    }
}
        