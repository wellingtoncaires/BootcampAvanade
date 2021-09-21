using AgenciaBancaria.Dominio;
using System;

namespace AgenciaBancaria.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Endereco endereco = new Endereco("Rua teste", "1234", "Pederneiras", "SP");
                Cliente cliente = new Cliente("Well", "123456", "4567833", endereco);

                ContaCorrente conta = new ContaCorrente(cliente, 100);
                Console.WriteLine("Conta criada: " + conta.Situacao + ": " +  conta.NumeroConta + "-" + conta.DigitoVerificador);

                string senha = "abc123456";
                conta.Abrir(senha);

                Console.WriteLine("Conta criada: " + conta.Situacao + ": " + conta.NumeroConta + "-" + conta.DigitoVerificador);

                conta.Sacar(10, senha);

                Console.WriteLine("Saldo: " + conta.Saldo);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
