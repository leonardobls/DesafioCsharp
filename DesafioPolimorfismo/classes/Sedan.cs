public class Sedan : Carro
{

    public bool PortaMalasEspacoso { get; set; }

    public Sedan(string nome, int cilindros, bool portaMalasEspacoso) : base(nome, cilindros)
    {
        PortaMalasEspacoso = portaMalasEspacoso;
    }

    public override void Ligar()
    {
        base.Ligar();
    }

    public override void Acelerar()
    {
        Console.WriteLine("Dificuldade para acelerar pois o porta malas está cheio pois estamos indo para a praia!\n\n");
    }

    public override void Frear()
    {
        base.Frear();
    }
}