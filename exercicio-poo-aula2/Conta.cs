using System;
using System.Collections.Generic;
using System.Text;

namespace poo_exercicio
{
    class Conta
    {
        private decimal Saldo { get; set; }
        private string Titular { get; }
        private int Numero { get; }

        public Conta(decimal saldo, string titular, int numero)
        {
            this.Saldo = saldo;
            this.Titular = titular;
            this.Numero = numero;
        }

        public void Depositar(decimal valor)
        {
            Saldo += valor; 
        }

        public void Sacar(decimal valor)
        {
            if (Saldo < valor)
            {
                throw new ErroSaldoInsuficiente();
            }

            Saldo -= valor;
        }

        
        public decimal ConsultarSaldo()
        {
            return Saldo;
        }
    }
}
