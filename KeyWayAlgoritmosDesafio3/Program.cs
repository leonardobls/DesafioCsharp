internal class Program
{
    static void Main(string[] args)
    {

        List<LanguagesDTO> languages = [];
        List<PhrasesDTO> phrases = [];
        languages.Add(new LanguagesDTO() { Language = "PT-BR", Country = "brasil" });
        languages.Add(new LanguagesDTO() { Language = "EN-US", Country = "estados unidos" });
        languages.Add(new LanguagesDTO() { Language = "ES", Country = "espanha" });
        bool loop = true;

        while (loop)
        {

            Console.WriteLine("|###############################################################|");
            Console.WriteLine("|                       Bem-vindo ao SPN                        |");
            Console.WriteLine("|                   Sistema do Papai Noel                       |");
            Console.WriteLine("|###############################################################|");
            Console.WriteLine("|                                                               |");
            Console.WriteLine("|  * Escolha uma das opções abaixo:                             |");
            Console.WriteLine("|                                                               |");
            Console.WriteLine("|      [1] - Inserir frase                                      |");
            Console.WriteLine("|      [2] - Remover frase                                      |");
            Console.WriteLine("|      [3] - Consultar frase                                    |");
            Console.WriteLine("|      [4] - Listar todas frases                                |");
            // Console.WriteLine("|      [5] - Inserir idioma                                     |");
            // Console.WriteLine("|      [6] - Remover idioma                                     |");
            // Console.WriteLine("|      [7] - Listar todos idioma                                |");
            Console.WriteLine("|                                                               |");
            Console.WriteLine("|      [0] - Sair                                               |");
            Console.WriteLine("|                                                               |");
            Console.WriteLine("|###############################################################|\n");


            string result;
            if (((result = Console.ReadLine()) != null) && int.TryParse(result, out int option))
            {
                switch (option)
                {
                    case 0:
                        Console.WriteLine("Saindo da aplicação...\nAté breve!\n\nHO!HO!HO\n\n\n");
                        loop = false;
                        break;

                    case 1:
                        Console.WriteLine("A opção 1 foi escolhida!\n\n");
                        HandleAddPhrase(languages, phrases);
                        break;
                    case 2:
                        Console.WriteLine("A opção 2 foi escolhida!\n\n");
                        HandleDeletePhrase(phrases);
                        break;
                    case 3:
                        Console.WriteLine("A opção 3 foi escolhida!\n\n");
                        SearchPhrase(phrases);
                        break;
                    case 4:
                        Console.WriteLine("A opção 4 foi escolhida!\n\n");
                        ListAllPhrases(phrases);
                        break;

                    default:
                        break;
                }
            }
            else
                break;
        }
    }

    static void HandleAddPhrase(List<LanguagesDTO> languages, List<PhrasesDTO> phrases)
    {

        bool loop = true;

        while (loop)
        {
            Console.WriteLine("|###############################################################|");
            Console.WriteLine("|                     ADICIONAR NOVA FRASE                      |");
            Console.WriteLine("|###############################################################|");
            Console.WriteLine("|                                                               |");
            Console.WriteLine("|  * Escolha abaixo em qual idioma gostaria de inserir:         |");
            Console.WriteLine("|                                                               |");
            if (languages.Count > 0)
            {
                for (int i = 0; i < languages.Count; i++)
                {
                    string spaces = "                            ";
                    string formattedLanguage = languages[i].Language.PadRight(spaces.Length);
                    string formattedCountry = languages[i].Country.PadRight(20);
                    Console.WriteLine($"|      [{i + 1}] - {formattedCountry} | {formattedLanguage}|");
                }
                Console.WriteLine("|                                                               |");
                Console.WriteLine("|      [0] - Voltar                                             |");

            }
            else
            {
                Console.WriteLine("|       ### NENHUM IDIOMA FOI ENCONTRADO NA BASE :(  ###        |");
                Console.WriteLine("|                                                               |");

            }
            Console.WriteLine("|###############################################################|");

            string result;
            if (((result = Console.ReadLine()) != null) && int.TryParse(result, out int option))
            {
                if (option != 0)
                {
                    AddPhraseToLanguage(languages[option - 1], phrases);
                }
                else
                    loop = false;
            }
        }
    }

    static void AddPhraseToLanguage(LanguagesDTO language, List<PhrasesDTO> phrases)
    {
        Console.WriteLine("Insira a phrase para o devido idioma:\n");
        string phrase = Console.ReadLine() ?? "";

        if (phrase != null && phrase != "")
        {
            phrases.Add(new PhrasesDTO() { Phrase = phrase, Language = language.Language, Country = language.Country });
            Console.WriteLine("Adicionado com Sucesso!!\n\n");

            Thread.Sleep(1000);
            TimerCount(3);
        }
        else
            Console.WriteLine("Não é possível inserir campos nulos!\n");

        return;
    }

    static void HandleDeletePhrase(List<PhrasesDTO> phrases)
    {
        bool loop = true;

        while (loop)
        {
            Console.WriteLine("|###############################################################|");
            Console.WriteLine("|                          REMOVER FRASE                        |");
            Console.WriteLine("|###############################################################|");
            Console.WriteLine("|                                                               |");
            Console.WriteLine("|  * Selecione qual das frases gostaria de remover:             |");
            Console.WriteLine("|                                                               |");
            if (phrases.Count > 0)
            {
                for (int i = 0; i < phrases.Count; i++)
                {
                    string spaces = "                                                   ";
                    string formattedPhrase = phrases[i].Phrase.PadRight(spaces.Length);
                    Console.WriteLine($"|      [{i + 1}] - {formattedPhrase}|");
                }
                Console.WriteLine("|                                                               |");
                Console.WriteLine("|      [0] - Voltar                                             |");


            }
            else
            {
                Console.WriteLine("|       ### NENHUMA FRASE FOI ENCONTRADO NA BASE :(  ###        |");
                Console.WriteLine("|                                                               |");
                Console.WriteLine("|      [0] - Voltar                                             |");

            }
            Console.WriteLine("|                                                               |");
            Console.WriteLine("|###############################################################|");

            string result;
            if (((result = Console.ReadLine()) != null) && int.TryParse(result, out int option))
            {
                if (option != 0)
                {
                    DeletePhrase(phrases, phrases[option - 1]);
                }
                else
                    loop = false;
            }
        }
    }

    static void DeletePhrase(List<PhrasesDTO> phrases, PhrasesDTO phraseToDelete)
    {
        Console.WriteLine($"Removendo a frase \"{phraseToDelete.Phrase}\"...\n\n");
        phrases.Remove(phraseToDelete);
        Thread.Sleep(3000);
        TimerCount(3);
    }

    static void SearchPhrase(List<PhrasesDTO> phrases)
    {
        Console.WriteLine("Insira o país: \n");
        string input = Console.ReadLine() ?? "";

        if (input != "")
        {
            string result = phrases.Where(p => p.Country == input.Trim()).FirstOrDefault()?.Phrase;

            if (result != null)
                Console.WriteLine($"{result}\n\n");
            else
                Console.WriteLine("--- NÃO ENCONTRADO --- \n\n");
        }
    }

    static void ListAllPhrases(List<PhrasesDTO> phrases)
    {
        if (phrases.Count > 0)
        {
            foreach (PhrasesDTO phrase in phrases)
            {
                string formattedLanguage = phrase.Language.PadRight(10);
                string formattedPhrase = phrase.Phrase.PadRight(20);

                Console.WriteLine($"\t|   IDIOMA: {formattedLanguage} | FRASE: {formattedPhrase}   |");
            }
        }
        else
        {
            Console.WriteLine("Nenhuma frase foi encontrada :(");
        }
        Console.WriteLine("\n\n");

        Thread.Sleep(1000);
        TimerCount(3);
    }

    static void TimerCount(int seconds)
    {
        Console.WriteLine("Voltando para a tela anterior...");

        for (int i = 0; i < seconds; i++)
        {
            Console.WriteLine($"{i + 1}");
            Thread.Sleep(1000);
        }
    }

}