using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ed2
{
    public class Livro
    {
        // auto properties
        public string Autores { get; set; }
        public string BestSellersRank { get; set; }
        public string Categorias { get; set; }
        public string Edicao { get; set; }
        public string Id { get; set; }
        public string Isbn10 { get; set; }
        public string Isbn30 { get; set; }
        public string MediaAvaliacoes { get; set; }
        public string NumAvaliacoes { get; set; }
        public string Titulo { get; set; }

        //metodos
        public Livro LerArquivo(string pathArquivo, int tamBloco)
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
