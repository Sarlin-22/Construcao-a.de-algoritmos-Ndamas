using System;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Digite o tamanho do tabuleiro (N):");
        int n = int.Parse(Console.ReadLine()!);
        if (n > 0)
        {
            ProblemaNDamas(n);
        }
    }
    static void Tabuleiro(bool[,] tabuleiro, int n)
    {

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(tabuleiro[i, j] ? "* " : ". ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    static bool Verificacao(bool[,] tabuleiro, int linha, int coluna, int n)
    {
        // linha acima da coluna
        for (int i = 0; i < linha; i++)
        {
            if (tabuleiro[i, coluna])
                return false;
        }
        // diagonal superior esquerda
        for (int i = linha, j = coluna; i >= 0 && j >= 0; i--, j--)
        {
            if (tabuleiro[i, j])
                return false;
        }
        // diagonal superior direita
        for (int i = linha, j = coluna; i >= 0 && j < n; i--, j++)
        {
            if (tabuleiro[i, j])
                return false;
        }

        return true;
    }
    static bool Ndamas(bool[,] tabuleiro, int linha, int n)
    {

        if (linha >= n)
        {
            Console.WriteLine("Esta e uma solução:");
            Tabuleiro(tabuleiro, n);
            return true;
        }

        bool resultado = false;
        for (int coluna = 0; coluna < n; coluna++)
        {
            if (Verificacao(tabuleiro, linha, coluna, n))
            {
                // colocar dama na posição
                tabuleiro[linha, coluna] = true;

                Console.WriteLine($"Tentar colocar dama em ({linha}, {coluna}):");
                Tabuleiro(tabuleiro, n);

                resultado = Ndamas(tabuleiro, linha + 1, n) || resultado;   /* encontra somente uma solucao */
                /* if (Ndamas(tabuleiro, linha + 1, n)) { 
                return true;
            } */

                // backtrack
                Console.WriteLine($"Remover dama de ({linha}, {coluna}) (uso de backtracking):");
                tabuleiro[linha, coluna] = false;
                Tabuleiro(tabuleiro, n);
            }
        }
        return resultado;
        /* return false; */
    }
    static void ProblemaNDamas(int n)
    {

        bool[,] tabuleiro = new bool[n, n];
        if (!Ndamas(tabuleiro, 0, n))
        {
            Console.WriteLine("Nenhuma solução foi encontrada.");
        }
    }
}