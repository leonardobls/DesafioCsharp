public class Ingrediente
{
    public int Id { get; set; }
    public required string Nome { get; set; }

    public required string Categoria { get; set; }

    public required string TipoDeMedida { get; set; }

    public required string QuantidadeNoEstoque { get; set; }

    public required string Slug { get; set; }

    public decimal PrecoDoAdicional { get; set; }

    public static List<Ingrediente> ListarTodosIngredientesPorCategoria(string categoria, List<Ingrediente> ingredientes)
    {
        return ingredientes.Where((i) => i.Categoria == categoria.Trim()).ToList();
    }
}