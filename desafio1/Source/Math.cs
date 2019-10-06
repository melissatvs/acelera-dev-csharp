using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Math
    {
        public List<int> Fibonacci()
        {
            List<int> resultado = new List<int>();
            int numero1 = 0;
            int numero2 = 1;
            int soma = numero1 + numero2;

            resultado.Add(numero1);
            resultado.Add(numero2);

            while (soma <= 350)
            {
                resultado.Add(soma);

                numero1 = numero2;
                numero2 = soma;

                soma = numero1 + numero2;
            }

            return resultado;
        }

        public bool IsFibonacci(int numberToTest)
        {
            if (numberToTest == 0 || numberToTest == 1)
            {
                return true;
            }

            int numero1 = 0;
            int numero2 = 1;
            int soma = numero1 + numero2;

            while (soma <= numberToTest)
            {
                if (numberToTest == soma)
                {
                    return true;
                }

                numero1 = numero2;
                numero2 = soma;

                soma = numero1 + numero2;
            }

            return false;
        }
    }
}
