
using System; 

namespace cpfBenchmark
{
    
    static class Final
    {
        static Func<char,int> ToValue = (char c) => c & 15;
        internal static bool IsCpf(string cpf)
        {

            int soma1 = 0, soma2=0;
            int valor=-1;
            bool todosIguais = true;

            ReadOnlySpan<char> cpfSpan = cpf.AsSpan();
            var digito = cpfSpan[^2..];
            if (!(char.IsDigit(digito[0]) && char.IsDigit(digito[1])))
            {
                return false;
            }
            var numero = cpfSpan[0..^2];
            int multiplicador = 11;
            for (int i = 0; i < numero.Length; i++)
            {
                if (char.IsDigit(numero[i]))
                {
                    todosIguais = todosIguais && numero[i] == numero[0];
                    valor = ToValue(numero[i]);
                    soma2 += valor * multiplicador--;
                    soma1 += valor * multiplicador; 
                }
            }
            if (todosIguais)
            {
                return false;
            }

            int dv1 = soma1 % 11;
            dv1 = dv1 < 2 ? 0: 11 - dv1;

            soma2 += dv1 * 2;

            int dv2 = soma2 % 11;
            dv2 = dv2 < 2 ? 0 : 11 - dv2;

            return (dv1,dv2)==(ToValue(digito[0]), ToValue(digito[1]));
        }
    }
}
