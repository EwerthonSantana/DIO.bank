using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.bank
{
    public enum TipoConta
    {
        PessoaFisica = 1,
        PessoaJuridica = 2,
        ONG = 3,
        Governamental = 4
    }
    public class Conta
    {
        public TipoConta TipoConta { get; set; }
        public string Nome { get; set; }
        public decimal Credito { get; set; }
        public decimal Saldo { get; set; }
        public Conta(TipoConta tipoConta, string nome, decimal credito, decimal saldo)
        {
            TipoConta = tipoConta;
            Nome = nome;
            Credito = credito;
            Saldo = saldo;
        }
        public bool Sacar(decimal valorSaque)
        {
            //Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é de {1}", this.Nome, this.Saldo);

            return true;
        }
        public void Depositar(decimal valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta é de {0} é {1}", this.Nome, this.Saldo);

        }
        public void Transferir(decimal valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
            return retorno;

        }
    }
}
