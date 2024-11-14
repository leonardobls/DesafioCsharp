namespace DesafioConstrutor.Classes
{
    public class Conta
    {
        public required int NumeroConta { get; set; }

        public required decimal Saldo { get; set; }

        public required string NomeCliente { get; set; }

        public required string Email { get; set; }

        public required string Telefone { get; set; }

        public void DepositoFundos()
        {
            Saldo++;
        }

        public void SaqueFundos()
        {
            Saldo--;
        }

    }
}