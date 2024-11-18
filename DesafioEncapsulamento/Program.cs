using Classes;

public class Program
{
    static void Main(string[] args)
    {

        bool loop = true;

        Impressora impressora = new Impressora(20, 20, true, 20);

        while (loop)
        {
            Console.WriteLine("ESCOLHA UMA OPÇÃO ABAIXO:");

            Console.WriteLine("\t [1] - Imprimir folha");
            Console.WriteLine("\t [2] - Imprimir conjunto de folhas [10 folhas por vez]");
            Console.WriteLine("\t [3] - Recarregar folha");
            Console.WriteLine("\t [4] - Trocar cartucho preto");
            Console.WriteLine("\t [5] - Trocar cartucho colorido");
            Console.WriteLine("\t [6] - Ver níveis dos cartuchos\n");
            Console.WriteLine("\t [0] - Sair");

            string input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                switch (number)
                {
                    case 0:
                        Console.WriteLine("Desligando impressora...");
                        Thread.Sleep(3000);
                        Console.WriteLine("Desligada.");
                        loop = false;
                        break;

                    case 1:
                        impressora.ImprimirFolha();
                        break;

                    case 2:
                        impressora.ImprimirFolhas();
                        break;

                    case 3:
                        impressora.RecarregarFolhas();
                        break;
                    case 4:
                        impressora.RecarregarCartuchoPreto();
                        break;
                    case 5:
                        impressora.RecarregarCartuchoColorido();
                        break;
                    case 6:
                        impressora.ExibeNiveisDeTinta();
                        break;

                }
            }
        }
    }
}