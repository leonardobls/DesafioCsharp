namespace Dtos
{
    public class HamburguerDeluxe : Hamburguer
    {

        public HamburguerDeluxe(string pao, string carne) : base(pao, carne)
        {
            BatataFrita = 1;
            Refrigerante = 1;
            ValorBase = 30;
            Categoria = "deluxe";
        }
    }
}