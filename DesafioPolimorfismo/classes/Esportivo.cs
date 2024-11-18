public class Esportivo : Carro
{
    public bool Turbo { get; set; }

    public Esportivo(string nome, int cilindros, bool turbo) : base(nome, cilindros)
    {
        Turbo = turbo;
    }

    public override void Ligar()
    {
        Console.WriteLine("Carro ligado e roncando porque é um ESPORTIVO!\n\n");
    }

    public override void Frear()
    {
        Console.WriteLine("Freiando muito porque estava muito rápido e era ESPORTIVO!\n\n");
    }

    public override void Acelerar()
    {
        Console.WriteLine("Zero a 100 em segundos porque é um ESPORTIVO!\n\n");
    }
}