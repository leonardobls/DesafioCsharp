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
            Console.WriteLine("|      [4] - Pedidos prontos                                    |");
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
                        // CancelarPedido();
                        break;

                    case 3:
                        // ListarPedidosEmAndamento();
                        break;

                    case 4:
                        // ListarPedidosProntos();
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

            if (int.TryParse(input, out int option))
            {
                switch (option)
                {

                    case 0:
                        loopSolicitacaoPedido = false;
                        break;

                    case 1:
                        string tipoDePao = EstoqueController.SolicitaOpcaoIngrediente("pao", GlobalData.globalIngredientes) ?? "";
                        string tipoDeHamburguer = EstoqueController.SolicitaOpcaoIngrediente("carne", GlobalData.globalIngredientes) ?? "";
                        Hamburguer hamburguer = new Hamburguer(tipoDePao, tipoDeHamburguer);
                        AdicionarAdicional(hamburguer);
                        GlobalData.globalPedidos.Add(hamburguer);
                        Console.WriteLine("\tPedido solicitado com sucesso!\n\tPassando para estágio de preparação... Por favor, aguarde!\n");
                        Thread.Sleep(3000);
                        break;

                    case 2:
                        // CancelarPedido();
                        break;

                    case 3:
                        // ListarPedidosEmAndamento();
                        break;

                    case 4:
                        // ListarPedidosProntos();
                        break;
                }
            }
        }
    }

    public static void AdicionarAdicional(Hamburguer hamburguer)
    {
        bool loop = true;

        List<PropertyInfo> attributes = typeof(Hamburguer).GetProperties().ToList();

        attributes.Remove(attributes.Where((a) => a.Name == "Pao").First());
        attributes.Remove(attributes.Where((a) => a.Name == "Carne").First());

        while (loop)
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
                    break;
                }
                else if (option == 1000)
                {
                    break;
                }
                else if (option > 0 && option <= attributes.Count)
                {

                    PropertyInfo selectedProperty = attributes[option - 1];

                    Console.WriteLine("\tInforme a quantidade de adicional ao item escolhido você gostaria de incrementar:\n\n");
                    string adicional = Console.ReadLine() ?? "";

                    if (int.TryParse(adicional, out int adicionalNumero))
                    {
                        int valorAtual = (int)(selectedProperty.GetValue(hamburguer) ?? 0);
                        selectedProperty.SetValue(hamburguer, valorAtual + adicionalNumero);
                    }
                }
                else
                {
                    Console.WriteLine("Valor inválido!\n");
                }
            }
        }
    }
}