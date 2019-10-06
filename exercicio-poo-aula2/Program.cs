using System;

namespace poo_exercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            Conta contaDaMelissa = new Conta(100, "Melissa", 9989898);

            contaDaMelissa.Depositar(50);
            Console.WriteLine(contaDaMelissa.ConsultarSaldo());

            contaDaMelissa.Sacar(1000);
            Console.WriteLine(contaDaMelissa.ConsultarSaldo());
        }
    }
}
