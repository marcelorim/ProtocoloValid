namespace Protocolo.Publisher.Business.Utils
{
    public static class Extensions
    {
        public static string GerarCpf()
        {
            int soma = 0, resto = 0;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Random rnd = new Random();
            string semente = rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            return semente;
        }

        public static string GerarRG()
        {
            // Gerar 8 números aleatórios de 0 a 9
            // Calcular esses 8 números e gerar o Dígito Verificador
            // Se o resto for igual a 0, DV = 0.
            // Se o resto for igual a 1, DV = X.
            // Se não, DV = 11 - resto.

            Random rnd = new Random();

            int n1 = rnd.Next(0, 10);
            int n2 = rnd.Next(0, 10);
            int n3 = rnd.Next(0, 10);
            int n4 = rnd.Next(0, 10);
            int n5 = rnd.Next(0, 10);
            int n6 = rnd.Next(0, 10);
            int n7 = rnd.Next(0, 10);
            int n8 = rnd.Next(0, 10);

            int soma = (n1 * 2) + (n2 * 3) + (n3 * 4) + (n4 * 5) + (n5 * 6) + (n6 * 7) + (n7 * 8) + (n8 * 9);

            int resto = soma % 11;
            string DV;

            if (resto == 0)
            {
                DV = "0";
            }
            else if (resto == 1)
            {
                DV = "X";
            }
            else
            {
                DV = (11 - resto).ToString();
            }

            return n1.ToString() + n2 + n3 + n4 + n5 + n6 + n7 + n8 + DV;
        }
    }
}
