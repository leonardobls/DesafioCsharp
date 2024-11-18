public class Carro
{

    public string Nome { get; set; }

    public bool Motor { get; set; }

    public int Cilindros { get; set; }

    public int Rodas { get; set; }

    public Carro(string nome, int cilindros)
    {
        Nome = Nome;
        Motor = true;
        Rodas = 4;
        Cilindros = Cilindros;
    }

    public virtual void Ligar()
    {
        Console.WriteLine("Carro Ligado!\n\n");
    }

    public virtual void Acelerar()
    {
        Console.WriteLine("Acelerando!\n\n");
    }

    public virtual void Frear()
    {
        Console.WriteLine("Freiando!\n\n");
    }
}