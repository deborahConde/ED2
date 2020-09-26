using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Linq;

namespace ed2
{

    public class Program
    {
        static void Main(string[] args)
        {
            Livro livros = new Livro();

            livros.LerArquivo("dataset_simp_sem_descricao.csv", 100);

            Console.WriteLine(livros[0].autores + " " + livros[0].bestSellersRank + " " + livros[0].categorias + " ");
            Console.WriteLine(livros[1].autores + " " + livros[1].bestSellersRank + " " + livros[1].categorias + " ");
            Console.WriteLine(livros[2].autores + " " + livros[2].bestSellersRank + " " + livros[2].categorias + " ");
        }

        public string[] RandomLinhas(string[] linhas, int tamBloco, int tamArqTotal)
        {
            int i = 0;
            string[] randLinhas = new string[tamBloco];  //Vetor q ira armazenar as linhas aleatorias
            bool[] jaGerado = new bool[tamArqTotal];     //Vetor que checa se a linha ja foi salva antes para evitar repetição de linhas
            Random rnd = new Random();
            while (i < tamBloco)
            {
                int linha = rnd.Next(tamArqTotal);
                if (!jaGerado[linha])
                {
                    jaGerado[linha] = true;
                    randLinhas[i] = linhas[linha];
                    i++;
                }
            }
            return randLinhas;
        }

        
    }
}

