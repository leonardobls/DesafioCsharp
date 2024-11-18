public class Program
{
    static void Main(string[] args)
    {
        Carro sedan = new Sedan("Toyota Corolla", 4, true);
        Carro suv = new Suv("Ford Explorer", 6, true);
        Carro esportivo = new Esportivo("Ferrari 488", 8, true);

        sedan.Ligar();
        suv.Ligar();
        esportivo.Ligar();

        sedan.Acelerar();
        suv.Acelerar();
        esportivo.Acelerar();

        sedan.Frear();
        suv.Frear();
        esportivo.Frear();
    }
}