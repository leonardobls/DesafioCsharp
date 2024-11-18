using Dtos;

class EstoqueController
{
    public static void TelaControleEstoque()
    {
        Console.WriteLine("Tela de controle de estoque...\n");
    }

    public static string SolicitaOpcaoIngrediente(string categoria, List<Ingrediente> ingredientes)
    {

        List<Ingrediente> opcoes = ingredientes.Where((i) => i.Categoria == categoria).ToList();

        Console.WriteLine("|###############################################################|");
        Console.WriteLine("|                     LISTA DE INGREDIENTES                     |");
        Console.WriteLine("|                                                               |");
        Console.WriteLine("|  * Escolha uma das opções abaixo:                             |");
        Console.WriteLine("|                                                               |");

        for (int i = 0; i < opcoes.Count; i++)
        {
            Console.WriteLine($"|      [{i + 1}] - {opcoes[i].Nome.PadRight(51)}|");
        }
        Console.WriteLine("|                                                               |");
        Console.WriteLine("|      [0] - Sair                                               |");
        Console.WriteLine("|###############################################################|\n\n");

        bool loop = true;
        string ingredienteSelecionado = "";

        while (loop)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                if (number == 0)
                {
                    loop = false;
                    break;
                }
                else
                {
                    ingredienteSelecionado = opcoes[number - 1].Nome;
                    break;
                }
            }
            else
            {
                Console.WriteLine("Por favor, insira apenas valores numéricos!\n");
            }
        }

        return ingredienteSelecionado;
    }
}