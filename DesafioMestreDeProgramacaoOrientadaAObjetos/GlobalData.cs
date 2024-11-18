using Dtos;

public static class GlobalData
{
    public static List<Ingrediente> globalIngredientes = new();
    public static List<Hamburguer> globalPedidos = new();

    static GlobalData()
    {
        globalIngredientes.Add(new Ingrediente() { Id = 1, Nome = "Pão Brioche", Slug = "pao-brioche", Categoria = "pao", TipoDeMedida = "unitario", QuantidadeNoEstoque = "10", PrecoDoAdicional = 4.5M });

        globalIngredientes.Add(new Ingrediente() { Id = 2, Nome = "Pão Italiano", Slug = "pao-italiano", Categoria = "pao", TipoDeMedida = "unitario", QuantidadeNoEstoque = "10", PrecoDoAdicional = 4.5M });

        globalIngredientes.Add(new Ingrediente() { Id = 3, Nome = "Pão Branco", Slug = "pao-branco", Categoria = "pao", TipoDeMedida = "unitario", QuantidadeNoEstoque = "10", PrecoDoAdicional = 4.5M });

        globalIngredientes.Add(new Ingrediente() { Id = 4, Nome = "Pão Integral", Slug = "pao-integral", Categoria = "pao", TipoDeMedida = "unitario", QuantidadeNoEstoque = "10", PrecoDoAdicional = 4.5M });

        globalIngredientes.Add(new Ingrediente() { Id = 5, Nome = "Pão Centeio", Slug = "pao-centeio", Categoria = "pao", TipoDeMedida = "unitario", QuantidadeNoEstoque = "10", PrecoDoAdicional = 4.5M });



        globalIngredientes.Add(new Ingrediente() { Id = 1, Nome = "Carne de Gado", Slug = "carne-de-gado", Categoria = "carne", TipoDeMedida = "gramas", QuantidadeNoEstoque = "500", PrecoDoAdicional = 10.0M });

        globalIngredientes.Add(new Ingrediente() { Id = 2, Nome = "Carne de Porco", Slug = "carne-de-porco", Categoria = "carne", TipoDeMedida = "gramas", QuantidadeNoEstoque = "500", PrecoDoAdicional = 10.0M });

        globalIngredientes.Add(new Ingrediente() { Id = 3, Nome = "Carne de Frango", Slug = "carne-de-frango", Categoria = "carne", TipoDeMedida = "gramas", QuantidadeNoEstoque = "500", PrecoDoAdicional = 10.0M });

        globalIngredientes.Add(new Ingrediente() { Id = 4, Nome = "Bife de Soja", Slug = "bife-de-soja", Categoria = "carne", TipoDeMedida = "gramas", QuantidadeNoEstoque = "500", PrecoDoAdicional = 10.0M });
    }
}