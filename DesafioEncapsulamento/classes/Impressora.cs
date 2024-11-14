
namespace Classes
{
    class Impressora
    {
        private int TempoDeImpressao { get; set; }

        private int NivelTintaPreta { get; set; }

        private int NivelTintaColorida { get; set; }

        private bool Duplex { get; set; }

        private int NumeroPaginas { get; set; }

        public Impressora(int nivelTintaPreta, int nivelTintaColorida, bool duplex, int numeroPaginas)
        {
            TempoDeImpressao = 5;
            NivelTintaPreta = nivelTintaPreta;
            NivelTintaColorida = nivelTintaColorida;
            Duplex = duplex;
            NumeroPaginas = numeroPaginas;
        }

        public void ExibeNiveisDeTinta()
        {
            Console.WriteLine($"Nível da Tinta Preta: {NivelTintaPreta}\n");
            Console.WriteLine($"Nível da Tinta Preta: {NivelTintaColorida}\n");
        }

        public void ImprimirFolha()
        {
            Console.WriteLine("Insira o conteúdo da impressão (serão aceitos apenas textos com 13 caracteres):\n");
            string impressao = Console.ReadLine();
            Console.WriteLine("Selecione o formato da impressão:\n\n");
            Console.WriteLine("\t[1] Colorido:");
            Console.WriteLine("\t[2] Preto e Branco:\n");

            string input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                switch (number)
                {
                    case 1:
                        ImpressaoUnica(true, impressao);
                        break;

                    case 2:
                        ImpressaoUnica(false, impressao);
                        break;

                }
            }
        }

        public void ImprimirFolhas()
        {

            Console.WriteLine("Selecione o formato da impressão:\n\n");
            Console.WriteLine("\t[1] Colorido:");
            Console.WriteLine("\t[2] Preto e Branco:\n");

            string input = Console.ReadLine();
            bool colorido = false;

            if (int.TryParse(input, out int number))
            {
                switch (number)
                {
                    case 1:
                        colorido = true;
                        break;

                    case 2:
                        break;

                }
            }

            for (int i = 0; i < 10; i++)
            {
                ImpressaoUnica(colorido, (i + 1).ToString());
            }
        }

        private void ImpressaoUnica(bool colorido, string impressao)
        {
            Console.WriteLine("Começando a impressão de uma folha!");
            Console.WriteLine("Aguarde...");
            if (NumeroPaginas > 0 && (colorido ? (NivelTintaColorida > 0) : NivelTintaPreta > 0))
            {
                if (colorido)
                    NivelTintaColorida -= 10;
                else
                    NivelTintaPreta -= 10;

                for (int i = 0; i < TempoDeImpressao; i++)
                {
                    Thread.Sleep(1000);

                    if (i == 0)
                    {
                        Console.WriteLine(" _______________ ");
                        Console.WriteLine($"| {impressao.PadRight(13)} |");
                    }
                    else if (i == TempoDeImpressao - 1)
                    {
                        Console.WriteLine("|   `           |");
                        Console.WriteLine("|_______________|\n\n");
                    }
                    else
                    {
                        Console.WriteLine("|          ´    |");
                        Console.WriteLine("|    `          |");
                    }
                }

                NumeroPaginas--;
            }
            else
            {
                Console.WriteLine("Verifique os níveis do cartucho ou se há folhas disponíveis!\n");
            }
        }
    }
}