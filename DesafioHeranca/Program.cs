using Classes;

class Program
{
    static void Main(String[] args)
    {
        Carro carro = new Carro(4, "Manual");

        carro.Ligar();
        carro.MudarMarcha(1);
        carro.Acelerar();
        carro.MudarMarcha(2);
        carro.Acelerar();
        carro.MudarMarcha(3);
        carro.Freiar();
        carro.MudarMarcha(1);
        carro.Acelerar();
        carro.MudarMarcha(2);
        carro.Freiar();
        carro.Desligar();
    }
}