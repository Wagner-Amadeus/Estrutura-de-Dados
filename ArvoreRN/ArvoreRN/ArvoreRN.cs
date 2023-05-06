
namespace ArvoreRN
{
    class ArvoreRN
    {
        public Node Raiz { get; set; }
        public Node Nulo { get; set; }

        public ArvoreRN()
        {
            Nulo = new Node();
            Raiz = Nulo;
        }





        // Métodos Privados da Classe //
        private void RotacaoEsquerda(Node x)
        {
            Node y = x.Direito;

            x.Direito = y.Esquerdo;
            if (y.Esquerdo != Nulo)
            {
                y.Esquerdo.Pai = x;
            }

            y.Pai = x.Pai;
            if (x.Pai == Nulo)
            {
                Raiz = y;
            }
            else
            {
                if (x == x.Pai.Esquerdo)
                {
                    x.Pai.Esquerdo = y;
                }
                else
                {
                    x.Pai.Direito = y;
                }
            }

            y.Esquerdo = x;
            x.Pai = y;
        }

        private void RotacaoDireita(Node y)
        {
            Node x = y.Esquerdo;

            y.Esquerdo = x.Direito;
            if (x.Direito != Nulo)
            {
                x.Direito.Pai = y;
            }

            x.Pai = y.Pai;
            if (y.Pai == Nulo)
            {
                Raiz = x;
            }
            else
            {
                if (y == y.Pai.Esquerdo)
                {
                    y.Pai.Esquerdo = x;
                }
                else
                {
                    y.Pai.Direito = x;
                }
            }

            x.Direito = y;
            y.Pai = x;
        }
    }
}
