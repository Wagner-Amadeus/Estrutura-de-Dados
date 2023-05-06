namespace ArvoreRN
{
    internal class Program
    {
        static void Main(string [] args)
        {
            ArvoreRN arvore = new ArvoreRN();
            arvore.Inserir(34);
            arvore.Inserir(3);
            arvore.Inserir(50);
            arvore.Inserir(20);
            arvore.Inserir(15);
            arvore.Inserir(16);
            arvore.Inserir(25);
            arvore.Inserir(27);
            arvore.Mostrar();
        }
    }
}