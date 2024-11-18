public class Program
{


    static void Main(string[] args)
    {
        bool loop = true;

        while (loop)
        {
            Console.WriteLine("|###############################################################|");
            Console.WriteLine("|                       Bem-vindo ao SGBB                       |");
            Console.WriteLine("|              Sistema de Gerenciamento Bills Burger            |");
            Console.WriteLine("|###############################################################|\n\n");

            Thread.Sleep(1000);

            Console.WriteLine("|###############################################################|");
            Console.WriteLine("|                         MENU PRINCIPAL                        |");
            Console.WriteLine("|                                                               |");
            Console.WriteLine("|  * Escolha uma das opções abaixo:                             |");
            Console.WriteLine("|                                                               |");
            Console.WriteLine("|      [1] - Pedidos                                            |");
            Console.WriteLine("|      [2] - Tela de controle de estoque                        |");
            Console.WriteLine("|      [3] - Fluxo do caixa                                     |");
            Console.WriteLine("|                                                               |");
            Console.WriteLine("|      [0] - Sair                                               |");
            Console.WriteLine("|###############################################################|\n\n");

            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out int option))
            {
                switch (option)
                {

                    case 0:
                        loop = false;
                        break;

                    case 1:
                        PedidoController.TelaPedidos();
                        break;

                    case 2:
                        EstoqueController.TelaControleEstoque();
                        break;

                    case 3:
                        CaixaController.TelaFluxoCaixa();
                        break;
                }
            }
        }
    }
}
