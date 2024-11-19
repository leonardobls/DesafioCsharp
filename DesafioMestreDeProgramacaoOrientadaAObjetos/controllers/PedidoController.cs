using System.Reflection;
using Dtos;

class PedidoController
{
    public static void TelaPedidos()
    {
        Console.WriteLine("Tela de pedidos...\n");

        bool loopTelaPedidos = true;

        while (loopTelaPedidos)
        {
            Console.WriteLine("|###############################################################|");
            Console.WriteLine("|                         TELA DE PEDIDOS                       |");
            Console.WriteLine("|                                                               |");
            Console.WriteLine("|  * Escolha uma das opções abaixo:                             |");
            Console.WriteLine("|                                                               |");
            Console.WriteLine("|      [1] - Novo pedido                                        |");
            Console.WriteLine("|      [2] - Cancelar pedido                                    |");
            Console.WriteLine("|      [3] - Pedidos em andamento                               |");
            Console.WriteLine("|                                                               |");
            Console.WriteLine("|      [0] - Voltar ao menu                                     |");
            Console.WriteLine("|###############################################################|\n\n");

            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out int option))
            {
                switch (option)
                {

                    case 0:
                        loopTelaPedidos = false;
                        break;

                    case 1:
                        NovoPedido();
                        break;

                    case 2:
                        CancelarPedido();
                        break;

                    case 3:
                        ListarPedidosEmAndamento();
                        break;
                }
            }
        }
    }

    public static void NovoPedido()
    {

        bool loopSolicitacaoPedido = true;

        while (loopSolicitacaoPedido)
        {
            Console.WriteLine("|###############################################################|");
            Console.WriteLine("|                      TELA DE NOVO PEDIDO                      |");
            Console.WriteLine("|                                                               |");
            Console.WriteLine("|  * Escolha uma das opções abaixo:                             |");
            Console.WriteLine("|                                                               |");
            Console.WriteLine("|      [1] - Modelo de hamburguer base                          |");
            Console.WriteLine("|      [2] - Modelo vegetariano                                 |");
            Console.WriteLine("|      [3] - Modelo deluxe                                      |");
            Console.WriteLine("|                                                               |");
            Console.WriteLine("|      [0] - Voltar                                             |");
            Console.WriteLine("|###############################################################|\n\n");

            string input = Console.ReadLine() ?? "";
            string pao = "", carne = "";

            if (int.TryParse(input, out int option))
            {
                switch (option)
                {

                    case 0:
                        loopSolicitacaoPedido = false;
                        break;

                    case 1:
                        pao = EstoqueController.SolicitaOpcaoIngrediente("base", "pao", GlobalData.globalIngredientes) ?? "";

                        if (pao == "")
                            break;

                        carne = EstoqueController.SolicitaOpcaoIngrediente("base", "carne", GlobalData.globalIngredientes) ?? "";

                        if (carne == "")
                            break;

                        Hamburguer hamburguerBase = new Hamburguer(pao, carne);
                        if (AdicionarAdicional(hamburguerBase) == 0)
                        {
                            break;
                        }
                        GlobalData.globalPedidos.Add(hamburguerBase);
                        Console.WriteLine($"\tVALOR FINAL DO PEDIDO: {hamburguerBase.CalculaValorTotal().ToString("C2", new System.Globalization.CultureInfo("pt-BR"))}\n");
                        Console.WriteLine("\tPedido solicitado com sucesso!\n\tPassando para estágio de preparação... Por favor, aguarde!\n");
                        Thread.Sleep(3000);

                        break;

                    case 2:
                        pao = EstoqueController.SolicitaOpcaoIngrediente("vegetariano", "pao", GlobalData.globalIngredientes) ?? "";

                        if (pao == "")
                            break;

                        carne = GlobalData.globalIngredientes.Where((i) => i.Slug == "bife-de-soja").First().Nome;

                        if (carne == "")
                            break;

                        Hamburguer hamburguerVegetariano = new HamburguerVegetariano(pao, carne);
                        if (AdicionarAdicional(hamburguerVegetariano) == 0)
                        {
                            break;
                        }
                        GlobalData.globalPedidos.Add(hamburguerVegetariano);
                        Console.WriteLine($"\tVALOR FINAL DO PEDIDO: {hamburguerVegetariano.CalculaValorTotal().ToString("C2", new System.Globalization.CultureInfo("pt-BR"))}\n");
                        Console.WriteLine("\tPedido solicitado com sucesso!\n\tPassando para estágio de preparação... Por favor, aguarde!\n");
                        Thread.Sleep(3000);

                        break;

                    case 3:
                        pao = EstoqueController.SolicitaOpcaoIngrediente("deluxe", "pao", GlobalData.globalIngredientes) ?? "";

                        if (pao == "")
                            break;

                        carne = EstoqueController.SolicitaOpcaoIngrediente("deluxe", "carne", GlobalData.globalIngredientes) ?? "";

                        if (carne == "")
                            break;

                        Hamburguer hamburguerDeluxe = new Hamburguer(pao, carne);
                        GlobalData.globalPedidos.Add(hamburguerDeluxe);
                        Console.WriteLine($"\tVALOR FINAL DO PEDIDO: {hamburguerDeluxe.CalculaValorTotal().ToString("C2", new System.Globalization.CultureInfo("pt-BR"))}\n");
                        Console.WriteLine("\tPedido solicitado com sucesso!\n\tPassando para estágio de preparação... Por favor, aguarde!\n");
                        Thread.Sleep(3000);

                        break;

                }
            }
        }
    }

    public static int AdicionarAdicional(Hamburguer hamburguer)
    {
        bool loop = true;
        int k = 0;

        List<PropertyInfo> attributes = typeof(Hamburguer).GetProperties().ToList();

        attributes.Remove(attributes.Where((a) => a.Name == "Pao").First());
        attributes.Remove(attributes.Where((a) => a.Name == "Carne").First());
        attributes.Remove(attributes.Where((a) => a.Name == "ValorBase").First());
        attributes.Remove(attributes.Where((a) => a.Name == "NumeroPedido").First());
        attributes.Remove(attributes.Where((a) => a.Name == "Categoria").First());

        while (loop && k < 4)
        {

            int i = 1;

            Console.WriteLine("|###############################################################|");
            Console.WriteLine("|                            ADICIONAL                          |");
            Console.WriteLine("|                                                               |");
            Console.WriteLine("|  * Escolha uma das opções abaixo:                             |");
            Console.WriteLine("|                                                               |");

            foreach (PropertyInfo property in attributes)
            {
                object? valor = property.GetValue(hamburguer);
                string nomeAtributo = property.Name.PadRight(i < 10 ? 15 : 14);
                string quantidade = $"(quantidade selecionada: {valor})".PadRight(33);

                Console.WriteLine($"|      [{i}] - {nomeAtributo} | {quantidade}|");

                i++;
            }

            Console.WriteLine("|                                                               |");
            Console.WriteLine("|      [0] - Voltar                                             |");
            Console.WriteLine("|      [1000] - Avançar                                         |");
            Console.WriteLine("|###############################################################|\n\n");

            string input = Console.ReadLine();

            if (int.TryParse(input, out int option))
            {
                if (option == 0)
                {
                    loop = false;
                    return 0;
                }
                else if (option == 1000)
                {
                    return 1;
                }
                else if (option > 0 && option <= attributes.Count)
                {

                    PropertyInfo selectedProperty = attributes[option - 1];

                    Console.WriteLine("\tInforme a quantidade de adicional ao item escolhido você gostaria de incrementar:\n\n");
                    string adicional = Console.ReadLine() ?? "";

                    if (int.TryParse(adicional, out int adicionalNumero))
                    {
                        if (adicionalNumero <= 4)
                        {
                            int.TryParse(selectedProperty.GetValue(hamburguer).ToString(), out int valorAtual);
                            selectedProperty.SetValue(hamburguer, valorAtual + adicionalNumero);
                            k++;
                        }
                        else
                        {
                            Console.WriteLine("Valor excedente!\n");
                            Thread.Sleep(3000);
                        }

                    }
                    else
                    {
                        Console.WriteLine("O valor deve ser um número de 1 a 4!\n");
                        Thread.Sleep(3000);
                    }
                }
                else
                {
                    Console.WriteLine("Valor inválido!\n");
                }
            }
        }

        return 0;
    }

    public static void CancelarPedido()
    {
        int i = 1;

        Console.WriteLine("|###############################################################|");
        Console.WriteLine("|                     CANCELAMENTO DE PEDIDOS                   |");
        Console.WriteLine("|                                                               |");
        Console.WriteLine("|  * Escolha uma das opções abaixo:                             |");
        Console.WriteLine("|                                                               |");

        if (GlobalData.globalPedidos.Count > 0)
        {
            foreach (var pedido in GlobalData.globalPedidos)
            {
                Console.WriteLine($"|      [{i}] Pedido #{pedido.NumeroPedido.PadRight(33)}|");
                i++;
            }
        }
        else
        {
            Console.WriteLine($"|      NENHUM PEDIDO REGISTRADO :( {("").PadRight(29)}|");
        }

        Console.WriteLine("|                                                               |");
        Console.WriteLine("|      [0] - Voltar                                             |");
        if (GlobalData.globalPedidos.Count > 0)
        {
            Console.WriteLine("|      [1000] - Avançar                                         |");
        }
        Console.WriteLine("|###############################################################|\n\n");

        string input = Console.ReadLine() ?? "";
        if (int.TryParse(input, out int number))
        {
            if (number == 0)
            {
                return;
            }
            else if (number > 0 && number <= GlobalData.globalPedidos.Count)
            {
                GlobalData.globalPedidos.Remove(GlobalData.globalPedidos[number - 1]);
                Console.WriteLine("\tPedido removido com sucesso!\n");
            }
            else
            {
                Console.WriteLine("O número inserido não é válido!\n");
            }
        }
        else
        {
            Console.WriteLine("Valor inserido não é um número!\n");
        }

        Thread.Sleep(3000);
    }


    public static void ListarPedidosEmAndamento()
    {
        foreach (Hamburguer hamburguer in GlobalData.globalPedidos)
        {
            Console.WriteLine($"\tPedido #{hamburguer.NumeroPedido}");
        }
        Console.WriteLine("\n");
        Thread.Sleep(3000);
    }
}