public class Suv : Carro
{

    public bool TracaoNas4Rodas { get; set; }

    public Suv(string nome, int cilindros, bool tracaoNas4Rodas) : base(nome, cilindros)
    {
        TracaoNas4Rodas = tracaoNas4Rodas;
    }

    public override void Ligar()
    {
        base.Ligar();
    }

    public override void Acelerar()
    {
        base.Acelerar();
    }

    public override void Frear()
    {
        base.Frear();
    }
}