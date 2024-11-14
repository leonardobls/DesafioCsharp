namespace Classes
{
    class Carro : Veiculo
    {
        public int QuantidadeDePortas { get; set; }

        public string TipoDeCambio { get; set; }

        public int Marcha { get; set; }

        public Carro(int quantidadeDePortas, string tipoDeCambio, int marcha = 0)
        {
            QuantidadeDePortas = quantidadeDePortas;
            TipoDeCambio = tipoDeCambio;
            Marcha = marcha;
        }

        public void MudarMarcha(int novaMarcha)
        {
            Marcha = novaMarcha;
            Console.WriteLine($"Mudando para a marcha {Marcha}");
        }
    }
}