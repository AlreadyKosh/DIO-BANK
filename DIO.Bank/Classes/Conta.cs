﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Bank
{
    class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque <(this.Credito *-1))
            {
                Console.WriteLine("Valor do Saldo Insuficiente");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine("Valor atual da conta de {0} é {1}", this.Nome, this.Saldo);
            return true;
        }

        public bool Depositar(double valorDeposito)
        {
          
            this.Saldo += valorDeposito;
            Console.WriteLine("Valor atual da conta de {0} é {1}", this.Nome, this.Saldo);
            return true;
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo Conta " + this.TipoConta + "  | ";
            retorno += "Nome  " + this.Nome + "  | ";
            retorno += "Saldo  " + this.Saldo + "  | ";
            retorno += "Credito  " + this.Credito;
            return retorno;
        }

    }
}
