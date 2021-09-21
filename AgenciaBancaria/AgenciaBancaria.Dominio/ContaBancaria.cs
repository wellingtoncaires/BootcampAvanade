using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    public abstract class ContaBancaria
    {
        public int NumeroConta { get; init; }
        public int DigitoVerificador { get; init; }
        public decimal Saldo { get; protected set; }
        public DateTime? DataAbertura { get; private set; }
        public DateTime? DataEncerramento { get; private set; }
        public SituacaoConta Situacao { get; private set; }
        public string Senha { get; private set; }
        public Cliente Cliente { get; set; }

        public ContaBancaria(Cliente cliente)
        {
            Random random = new Random();
            NumeroConta = random.Next(50000, 100000);
            DigitoVerificador = random.Next(0, 9);

            Situacao = SituacaoConta.Criada;
            Cliente = cliente ?? throw new Exception("Cliente deve ser informado");
        }

        public void Abrir(string senha)
        {
            SetaSenha(senha);

            Situacao = SituacaoConta.Aberta;
            DataAbertura = DateTime.Now;
        }

        private void SetaSenha(string senha)
        {
            Senha = senha.ValidaStringVazia();

            if(!Regex.IsMatch(senha, @"^(?=.*?[a-z])(?=.*?[0-9]).{8,}$"))
            {
                throw new Exception("Senha inválida");
            }

            Senha = senha;
        }

        public virtual void Sacar(decimal valor, string senha)
        {
            if (Senha != senha)
            {
                throw new Exception("Senha inválida.");
            }

            if (Saldo < valor)
            {
                throw new Exception("Saldo insuficiente.");
            }
            Saldo -= valor;
        }

        public virtual void Depositar(decimal valor, int numeroConta, int digitoVerificador)
        {
            if (NumeroConta != numeroConta || DigitoVerificador != digitoVerificador)
            {
                throw new Exception("Conta inválida");
            }

            Console.WriteLine("Confirme os dados:");
            Console.WriteLine($"Conta: {NumeroConta}-{DigitoVerificador}  Cliente: {Cliente.Nome}");
            Console.Write("[S/N]: ");
            char confirmacao = char.Parse(Console.ReadLine().Trim().ToUpper());

            if (confirmacao == 'S')
            {
                Saldo += valor;
            }
            else if (confirmacao == 'N')
            {
                Console.WriteLine("Opreação cancelada.");
            }
            else
            {
                throw new Exception("Operação Inválida");
            }
        }
    }

 
}
