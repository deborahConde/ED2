using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Linq;

namespace Ordenacoes
{
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

        public Livros[] LerArquivo(string pathArquivo, int tamBloco)
        {
            int contCampo = 0;
            string[] todasLinhas = File.ReadAllLines(@pathArquivo); //Le o arquivo todo
            int tamArqTotal = todasLinhas.Length;
            string[] linhas = RandomLinhas(todasLinhas, tamBloco, tamArqTotal);//Reduz para o tamanho do bloco desejado e aleatoriza as linhas
            Livros[] livros = new Livros[tamBloco];


            for (int i = 0; i < linhas.Length; i++)
            {
                string[] campo = linhas[i].Split('"');

                for (int j = 0; j < campo.Length; j++)
                {
                    if (j != 0 && j != campo.Length - 1)                    //Inicio e final das linhas contem uma string vazia
                    {
                        if (campo[j] != ",")
                        {
                            switch (contCampo)
                            {
                                case 0:
                                    livros[i].autores = campo[j];
                                    break;
                                case 1:
                                    livros[i].bestSellersRank = campo[j];
                                    break;
                                case 2:
                                    livros[i].categorias = campo[j];
                                    break;
                                case 3:
                                    livros[i].edicao = campo[j];
                                    break;
                                case 4:
                                    livros[i].id = campo[j];
                                    break;
                                case 5:
                                    livros[i].isbn10 = campo[j];
                                    break;
                                case 6:
                                    livros[i].isbn13 = campo[j];
                                    break;
                                case 7:
                                    livros[i].mediaAvaliacoes = campo[j];
                                    break;
                                case 8:
                                    livros[i].numAvaliacoes = campo[j];
                                    break;
                                case 9:
                                    livros[i].titulo = campo[j];
                                    break;
                                default:
                                    break;
                            }
                            contCampo++;
                            if (contCampo == 10)
                            {
                                contCampo = 0;
                            }
                        }
                    }
                }
            }
            return livros;
        }
    }
}

