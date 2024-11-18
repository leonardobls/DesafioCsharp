using System.Reflection;

namespace Dtos
{
    public class Hamburguer
    {
        public string NumeroPedido { get; set; }
        public string Carne { get; set; }

        public string Pao { get; set; }

        public int Alface { get; set; }

        public int Tomate { get; set; }

        public int Cenoura { get; set; }

        public int Pepino { get; set; }

        public int Cebola { get; set; }

        public int Pimenta { get; set; }

        public int BatataFrita { get; set; }

        public int CebolaFrita { get; set; }

        public int Refrigerante { get; set; }

        public int Suco { get; set; }

        public int Vinho { get; set; }

        public int Agua { get; set; }

        public decimal ValorBase { get; set; }

        public Hamburguer(string pao, string carne)
        {
            NumeroPedido = String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);
            Pao = pao;
            Carne = carne;
            Alface = 1;
            Tomate = 1;
            Cenoura = 0;
            Pepino = 1;
            Cebola = 1;
            Pimenta = 0;
            BatataFrita = 0;
            CebolaFrita = 0;
            Refrigerante = 0;
            Suco = 0;
            Vinho = 0;
            Agua = 0;
            ValorBase = 20.0M;
        }

        public decimal CalculaValorTotal()
        {
            decimal valorTotalFinal = ValorBase;

            // Obtém as propriedades da classe Hamburguer
            List<PropertyInfo> attributes = typeof(Hamburguer).GetProperties().ToList();

            // Itera sobre as propriedades e soma o valor dos atributos inteiros
            foreach (var property in attributes)
            {
                // Verifica se a propriedade é do tipo inteiro
                if (property.PropertyType == typeof(int))
                {
                    // Obtém o valor do atributo
                    int valorAtributo = (int)property.GetValue(this);

                    // Adiciona ao valor total multiplicando o valor do atributo pelo custo adicional (por exemplo, 4)
                    valorTotalFinal += valorAtributo * 4;
                }
            }

            return valorTotalFinal;
        }
    }
}