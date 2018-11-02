using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSaver.Utilities
{
    public static class Validador
    {
        public static bool EmailIsValid(string aEmail)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(aEmail);

                return addr.Address == aEmail;
            }
            catch
            {
                return false;
            }
        }

        public static bool PasswordIsValid(string aPassword)
        {
            if (string.IsNullOrEmpty(aPassword) || aPassword.Length < 6)
            {
                return false;
            }

            return true;
        }
    }
}
