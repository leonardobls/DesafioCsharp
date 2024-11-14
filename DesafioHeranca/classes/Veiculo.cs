namespace Classes
{
    class Veiculo
    {
        public string? Placa { get; set; }

        public string? Cor { get; set; }

        public string? Marca { get; set; }

        public int Ano { get; set; }

        public void Acelerar()
        {
            Console.WriteLine("ACELERANDOO VRUUMMMM");
        }

        public void Freiar()
        {
            Console.WriteLine("FREIANDOOOOO");
        }

        public void Ligar()
        {
            Console.WriteLine("LIGANDO...");
        }

        public void Desligar()
        {
            Console.WriteLine("DESLIGADO!");
        }
    }
}