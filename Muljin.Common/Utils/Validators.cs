using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Muljin.Utils
{
    public static partial class Validators
    {
        public static void ValidateEmail(string email)
        {
            if (String.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine($"{DateTime.UtcNow} - Invalid email. Null or default.");
                throw new ArgumentNullException(nameof(email), "Invalid email");
            }

            try
            {
                var e = new MailAddress(email);
            }
            catch
            {
                Console.WriteLine($"{DateTime.UtcNow} - Invalid email. Failed. {email}");
                throw new ArgumentException("Invalid email format", nameof(email));
            }
        }
    }
}
