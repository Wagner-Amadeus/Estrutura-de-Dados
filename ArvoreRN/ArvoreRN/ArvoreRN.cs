
using System.Text.Json.Nodes;

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

        public void Remover(int dado)
        {
            Node n = Busca(dado);
            if (n == Nulo)
            {
                return;
            }

            Node pai = n.Pai;

            //Caso 1 : Nodo sem filhos
            if (IsExternal(n))
            {
                if (pai == Nulo)
                {
                    Raiz = Nulo;
                }
                else if (n == pai.Esquerdo)
                {
                    pai.Esquerdo = Nulo;
                }
                else
                {
                    pai.Direito = Nulo;
                }
            }

            // Caso 2 : Nodo com um filho
            else if (n.Esquerdo == Nulo || n.Direito == Nulo)
            {
                Node filho = n.Esquerdo == Nulo ? n.Esquerdo : n.Direito;
                if (pai == Nulo)
                {
                    Raiz = filho;
                }
                else if (n == pai.Esquerdo)
                {
                    pai.Esquerdo = filho;
                }
                else
                {
                    pai.Direito = filho;
                }
                filho.Pai = pai;
            }

            // Caso 3 : Nodo com 2 filhos
            else
            {
                Node sucessor = Sucessor(n);
                n.Key = sucessor.Key;
                pai = sucessor.Pai;

                if (sucessor == n.Direito)
                {
                    pai = n;
                }
                if (sucessor == pai.Esquerdo)
                {
                    pai.Esquerdo = sucessor.Direito;
                }
                else
                {
                    pai.Direito = sucessor.Direito;
                }
                if (sucessor.Direito != Nulo)
                {
                    sucessor.Direito.Pai = pai;
                }
            }

            RestaurarPropriedadesRN(n);
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

        private bool IsExternal(Node n)
        {
            return (n.Direito == Nulo && n.Esquerdo == Nulo);
        }

        private Node Sucessor(Node n)
        {
            if (n == Nulo)
            {
                return Nulo;
            }

            if (n.Direito != Nulo)
            {
                Node Aux = n.Direito;
                while (Aux.Esquerdo != Nulo)
                {
                    Aux = Aux.Esquerdo;
                }
                return Aux;
            }

            else
            {
                Node Aux = n.Pai;
                while (Aux != Nulo && n == Aux.Direito)
                {
                    n = Aux;
                    Aux = Aux.Pai;
                }
                return Aux;
            }
        }

        // Método de Busca Auxiliar para remover nodos
        private Node Busca (int key)
        {
            Node atual = Raiz;
            while (atual != Nulo && atual.Key != key)
            {
                if (key < atual.Key)
                {
                    atual = atual.Esquerdo;
                }
                else
                {
                    atual = atual.Direito;
                }
            }
            return atual;
        }
    }
}