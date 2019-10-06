using System;
using System.Runtime.Serialization;

namespace poo_exercicio
{
    [Serializable]
    internal class ErroSaldoInsuficiente : Exception
    {
        const string mensagem = "Saldo insuficiente :(";

        public ErroSaldoInsuficiente() : base(mensagem)
        {
        }
        
    }
}