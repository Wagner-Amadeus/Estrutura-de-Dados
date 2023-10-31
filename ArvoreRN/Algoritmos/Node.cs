namespace ArvoreRN
{
    internal class Node
    {
        public int Key { get; set; }
        public Node Pai { get; set; }
        public Node Esquerdo { get; set; }
        public Node Direito { get; set; }
        public Cor Cor { get; set; }

        public Node()
        {
            Key = 0;
            Esquerdo = Direito = Pai = null;
            Cor = Cor.preto;
        }

        public Node (int key)
        {
            Key = key;
            Esquerdo = Direito = Pai = null;
            Cor = Cor.preto;
        }
    }
}
