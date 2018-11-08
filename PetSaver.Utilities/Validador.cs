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

        public static bool CpfIsValid(string aDocumento)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            aDocumento = aDocumento.Trim().Replace(".", "").Replace("-", "");

            if (aDocumento.Length != 11)
            {
                return false;
            }

            for (int j = 0; j < 10; j++)
            {
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == aDocumento)
                {
                    return false;
                }
            }

            string tempCpf = aDocumento.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            }

            int resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            string digito = resto.ToString();

            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = digito + resto.ToString();

            return aDocumento.EndsWith(digito);
        }

        public static bool CnpjIsValid(string aDocumento)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempaDocumento;

            aDocumento = aDocumento.Trim();
            aDocumento = aDocumento.Replace(".", "").Replace("-", "").Replace("/", "");

            if (aDocumento.Length != 14)
            {
                return false;
            }

            tempaDocumento = aDocumento.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
            {
                soma += int.Parse(tempaDocumento[i].ToString()) * multiplicador1[i];
            }

            resto = (soma % 11);

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = resto.ToString();
            tempaDocumento = tempaDocumento + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
            {
                soma += int.Parse(tempaDocumento[i].ToString()) * multiplicador2[i];
            }

            resto = (soma % 11);

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = digito + resto.ToString();

            return aDocumento.EndsWith(digito);
        }
    }
}
