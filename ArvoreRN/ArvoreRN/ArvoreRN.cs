
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

        public void Inserir(int dado)
        {
            Node ant = Nulo;
            Node p = Raiz;

            while (p != Nulo)
            {
                ant = p;
                if (dado > p.Key)
                {
                    p = p.Direito;
                }
                else if (dado < p.Key)
                {
                    p = p.Esquerdo;
                }
                else if (dado == p.Key)
                {
                    return;
                }
            }

            Node NewNode = new Node(dado);
            NewNode.Pai = ant;
            NewNode.Direito = NewNode.Esquerdo = Nulo;
            NewNode.Cor = Cor.vermelho;

            if (Raiz == Nulo)
            {
                Raiz = NewNode;
            }
            else
            {
                if (NewNode.Key > ant.Key)
                {
                    ant.Direito = NewNode;
                }
                else
                {
                    ant.Esquerdo = NewNode;
                }
            }
            // Fim do método convencional de inserção de Node em Árvores Binárias

            RestaurarPropriedadesRN(NewNode);
        }

        public void Mostrar()
        {
            InOrdem(Raiz, "    ");
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

        private void RestaurarPropriedadesRN(Node x)
        {
            Node y; //Tio de Node x

            while (x.Pai.Cor == Cor.vermelho)
            {
                if (x.Pai == x.Pai.Pai.Esquerdo)            // O tio de X estar a Direita
                {
                    y = x.Pai.Pai.Direito;
                    if (y.Cor == Cor.vermelho)              // Caso 1 : Colorir
                    {
                        y.Cor = Cor.preto;
                        x.Pai.Cor = Cor.preto;
                        x.Pai.Pai.Cor = Cor.vermelho;
                        x = x.Pai.Pai;
                    }
                    else
                    {
                        if (x == x.Pai.Direito)             // Caso 2 : X é filho direito e tem um tio Preto
                        {
                            x = x.Pai;
                            RotacaoEsquerda(x);
                        }
                        else                                // Caso 3 : X é filho esquerdo e tem um tio Preto
                        {
                            x.Pai.Cor = Cor.preto;
                            x.Pai.Pai.Cor = Cor.vermelho;
                            RotacaoDireita(x.Pai.Pai);
                        }
                    }
                }

                else                                       // O tipo de X estar a esquerda
                {
                    y = x.Pai.Pai.Esquerdo;
                    if (y.Cor == Cor.vermelho)             // Caso 1 : Colorir
                    {
                        y.Cor = Cor.preto;
                        x.Pai.Cor = Cor.preto;
                        x.Pai.Pai.Cor = Cor.vermelho;
                        x = x.Pai.Pai;
                    }
                    else
                    {
                        if (x == x.Pai.Esquerdo)           // Caso 2 (espelhamento)
                        {
                            x = x.Pai;
                            RotacaoDireita(x);
                        }
                        else                                // Caso 3 (espelhamento) : X é filho esquerdo e tem um tio Preto
                        {
                            x.Pai.Cor = Cor.preto;
                            x.Pai.Pai.Cor = Cor.vermelho;
                            RotacaoEsquerda(x.Pai.Pai);
                        }
                    }
                }
            }
            Raiz.Cor = Cor.preto;
        }
    
        private void InOrdem(Node p, string espaco)
        {
            if (p != Nulo)
            {
                InOrdem(p.Esquerdo, "        " + espaco);
                Console.WriteLine(espaco + p.Key + "," + p.Cor);
                InOrdem(p.Direito, "         " + espaco);
            }
        }
    }
}