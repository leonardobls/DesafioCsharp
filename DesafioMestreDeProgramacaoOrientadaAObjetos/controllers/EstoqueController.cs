using Dtos;

class EstoqueController
{
    public static void TelaControleEstoque()
    {
        bool loop = true;

        while (loop)
        {
            Console.WriteLine("|###############################################################|");
            Console.WriteLine("|                     LISTA DE INGREDIENTES                     |");
            Console.WriteLine("|                                                               |");

            // Cabeçalho das colunas
            Console.WriteLine("| Nome                  | Tipo de Medida      | Quantidade      |");
            Console.WriteLine("|-----------------------|---------------------|-----------------|");

            // Exibe os ingredientes
            foreach (var ingrediente in GlobalData.globalIngredientes)
            {
                string nome = ingrediente.Nome.PadRight(21);
                string tipoDeMedida = ingrediente.TipoDeMedida.PadRight(19);
                string quantidade = ingrediente.QuantidadeNoEstoque.ToString().PadRight(15);

                Console.WriteLine($"| {nome} | {tipoDeMedida} | {quantidade} |");
            }

            Console.WriteLine("|                                                               |");
            Console.WriteLine("|      [0] - Voltar ao menu                                     |");
            Console.WriteLine("|###############################################################|\n\n");

            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out int option))
            {
                switch (option)
                {
                    case 0:
                        loop = false;
                        break;
                }
            }
        }
    }


    public static string SolicitaOpcaoIngrediente(string hamburguerCategoria, string categoria, List<Ingrediente> ingredientes)
    {

        List<Ingrediente> opcoes = ingredientes.Where((i) => i.Categoria == categoria).ToList();

        if (categoria == "pao" && hamburguerCategoria != "vegetariano")
        {
            Ingrediente? ingrediente = opcoes.Where((i) => i.Slug == "pao-centeio").FirstOrDefault();

            if (ingrediente != null)
            {
                opcoes.Remove(ingrediente);
            }
        }

        if (categoria == "carne" && hamburguerCategoria != "vegetariano")
        {
            Ingrediente? ingrediente = opcoes.Where((i) => i.Slug == "bife-de-soja").FirstOrDefault();

            if (ingrediente != null)
            {
                opcoes.Remove(ingrediente);
            }
        }

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
                else if (number > 0 && number <= opcoes.Count)
                {
                    ingredienteSelecionado = opcoes[number - 1].Nome;
                    break;
                }
                else
                {
                    Console.WriteLine("Opção Inválida!\n");
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