namespace Dtos
{
    public class HamburguerVegetariano : Hamburguer
    {

        public bool PaoAdicional { get; set; }

        public HamburguerVegetariano(string pao, string carne) : base(pao, carne)
        {
            BatataFrita = 1;
            Refrigerante = 1;
            PaoAdicional = true;
            ValorBase = 25;
        }
    }
}