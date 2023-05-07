namespace ArvoreRN
{
    internal class Program
    {
        static void Main(string [] args)
        {
            ArvoreRN arvore = new ArvoreRN();


            arvore.Inserir(25);
            arvore.Mostrar();
            Console.WriteLine("\n\n\n\n\n");

            arvore.Inserir(30);
            arvore.Mostrar();
            Console.WriteLine("\n\n\n\n\n");

            arvore.Inserir(35);
            arvore.Mostrar();
            Console.WriteLine("\n\n\n\n\n");

            arvore.Inserir(50);
            arvore.Mostrar();
            Console.WriteLine("\n\n\n\n\n");

            arvore.Inserir(9);
            arvore.Mostrar();
            Console.WriteLine("\n\n\n\n\n");

            arvore.Inserir(15);
            arvore.Mostrar();
            Console.WriteLine("\n\n\n\n\n");


            arvore.Remover(15);
            arvore.Mostrar();
            Console.WriteLine("\n\n\n\n\n");


            arvore.Remover(30);
            arvore.Mostrar();
            Console.WriteLine("\n\n\n\n\n");


            arvore.Remover(9);
            arvore.Mostrar();
            Console.WriteLine("\n\n\n\n\n");

            arvore.Remover(50);
            arvore.Mostrar();
            Console.WriteLine("\n\n\n\n\n");

            arvore.Remover(25);
            arvore.Mostrar();
            Console.WriteLine("\n\n\n\n\n");
        }
    }
}