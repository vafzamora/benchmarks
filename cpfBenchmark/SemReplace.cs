
using System; 

namespace cpfBenchmark
{
    static class SemReplace
    {
        internal static bool IsCpf(string cpf)
        {

            //cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            //if (cpf.Length != 11)
            //    return false;
            var charCpf = new char[11];
            int j = 0;
            for (int i = 0; i < cpf.Length; i++){
                if (char.IsDigit(cpf[i]))
                {
                    charCpf[j++] = cpf[i];
                }
            }
            if (j < 11) {
                return false;
            }

            bool todosIguais = true;
            for (int i = 1; i < cpf.Length; i++){
                todosIguais = todosIguais || cpf[i] == cpf[i - 1];
            }
            if (todosIguais)
            {
                return false; 
            }

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            //multiplicador vira inteiro
            int multiplicador = 10; 
            for (int i = 0; i < 9; i++)
                soma += (charCpf[i]-48) * multiplicador--; //usa e decrementa multiplicador
            //soma += int.Parse(tempCpf[i].ToString()) * multiplicador--; //usa e decrementa multiplicador

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            charCpf[9] = (char)(48 + resto); 
            soma = 0;

            //reseta o multiplicador
            multiplicador = 11;
            for (int i = 0; i < 10; i++)
                soma += (charCpf[i] - 48) * multiplicador--; //usa e decrementa multiplicador

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            charCpf[9] = (char)(48 + resto);

            return cpf[9]==charCpf[9] && cpf[10]==charCpf[10];
        }
    }
}
