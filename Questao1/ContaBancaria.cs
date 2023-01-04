using System.Globalization;

namespace Questao1
{
    class ContaBancaria 
    {
        public int Numero { get; private set; }
        public string Titular { get; set; }
        public double Saldo { get; private set; } = 0;
        private const double TAXA_DE_SAQUE = 3.50;

        public ContaBancaria(int numero, string titular)
        {
            Numero = numero;
            Titular = titular;
        }

        public ContaBancaria(int numero, string titular, double depositoInicial) : this(numero, titular)
        {
            Saldo = depositoInicial;
        }

        public void Deposito(double quantia)
        {
            Saldo += quantia;
        }

        public void Saque(double quantia)
        {
            Saldo -= quantia + TAXA_DE_SAQUE;
        }

        public override string ToString()
        {
            return $"Conta {Numero}, Titular: {Titular}, Saldo: $ {Saldo.ToString("N2", CultureInfo.InvariantCulture)}";
        }

    }
}
