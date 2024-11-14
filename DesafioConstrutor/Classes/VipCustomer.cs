namespace DesafioConstrutor.Classes
{
    public class VipCustomer
    {

        public string Nome { get; }

        public decimal LimiteCredito { get; }

        public string Email { get; }

        public VipCustomer()
        {
            Nome = "Leonardo";
            LimiteCredito = 5000;
            Email = "leonardo.lima@keyworks.com";
        }

        public VipCustomer(string nome, decimal limiteCredito)
        {
            Nome = nome;
            LimiteCredito = limiteCredito;
            Email = "leonardo.lima@keyworks.com";
        }

        public VipCustomer(string nome, decimal limiteCredito, string email)
        {
            Nome = nome;
            LimiteCredito = limiteCredito;
            Email = email;
        }
    }
}