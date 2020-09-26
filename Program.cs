using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Linq;

namespace Ordenacoes
{

    /*public class Livros
    {

         public string autores, bestSellersRank, categorias, edicao, id, isbn10, isbn13, mediaAvaliacoes, numAvaliacoes, titulo; 
            
         public Livros()
        {
            autores = "";
            bestSellersRank = "";
            categorias = "";
            edicao = "";
            id = "";
            isbn10 = "";
            isbn13 = "";
            mediaAvaliacoes = "";
            numAvaliacoes = "";
            titulo = "";
        }
       
    }*/

    public struct Livros
    {
        public string autores, bestSellersRank, categorias, edicao, id, isbn10, isbn13, mediaAvaliacoes, numAvaliacoes, titulo;
    }

    class Program
    {


        static void Main(string[] args)
        {

            Livros[] livros = LerArquivo("dataset_simp_sem_descricao.csv", 100);
            Console.WriteLine(livros[0].autores + " " + livros[0].bestSellersRank + " " + livros[0].categorias + " ");
            Console.WriteLine(livros[1].autores + " " + livros[1].bestSellersRank + " " + livros[1].categorias + " ");
            Console.WriteLine(livros[2].autores + " " + livros[2].bestSellersRank + " " + livros[2].categorias + " ");

        }


        public static string[] RandomLinhas(string[] linhas, int tamBloco, int tamArqTotal)
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

        public static Livros[] LerArquivo(string pathArquivo, int tamBloco)
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


        public static int[] CreateArray(int tam)
        {
            Random randNum = new Random();
            int[] vet = new int[tam];
            for (int i = 0; i < tam; i++)
            {
                vet[i] = randNum.Next(0, 10000);
            }

            return vet;
        }//Cria e retorna um vetor aleatorio

        public static void Trocar(int[] vet, int i, int j)
        {
            int aux = vet[i];
            vet[i] = vet[j];
            vet[j] = aux;
        }//Troca duas posições em um vetor

        public static void ImprimeVetor(int[] vet, int tam)
        {
            for (int i = 0; i < tam; i++)
            {
                if (i == tam - 1)
                {
                    Console.Write(vet[i]);
                }
                else
                {
                    Console.Write(vet[i] + ", ");
                }
            }
        }//Imprime o vetor na tela

        public static void BubbleSort(int[] vet, int tam)
        {
            for (int i = tam - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (vet[j] > vet[j + 1])
                    {
                        Trocar(vet, j, j + 1);
                    }
                }
            }
        }//Algoritmo de ordenação BubbleSort

        public static void SelectionSort(int[] vet, int tam)
        {
            for (int i = 0; i < tam; i++)
            {
                int min = i;
                for (int j = i; j < tam; j++)
                {
                    if (vet[j] < vet[min])
                    {
                        min = j;
                    }
                }
                Trocar(vet, i, min);
            }
        }//Algoritmo de ordenação SelectionSort

        public static void InsertionSort(int[] vet, int tam)
        {
            for (int j = 1; j < tam; j++)
            {
                int pivo = vet[j];
                int i = j - 1;
                while ((i >= 0) && (vet[i] > pivo))
                {
                    vet[i + 1] = vet[i];
                    i--;
                }
                vet[i + 1] = pivo;
            }
        }//Algoritmo de ordenação InsertionSort

        public static void Merge(int[] vet, int inicio, int meio, int fim)
        {
            int[] aux = new int[fim - inicio + 1];
            int i = inicio, j = meio + 1, k = 0;
            while (i <= meio && j <= fim)
            {
                if (vet[i] <= vet[j])
                {
                    aux[k] = vet[i];
                    i++;
                }
                else
                {
                    aux[k] = vet[j];
                    j++;
                }
                k++;
            }
            while (i <= meio)
            {
                aux[k] = vet[i];
                i++;
                k++;
            }
            while (j <= fim)
            {
                aux[k] = vet[j];
                j++;
                k++;
            }
            for (int u = 0; u < fim - inicio + 1; u++)
            {
                vet[inicio + u] = aux[u];
            }
        }//Algoritmo de uniao do MergeSort

        public static void MergeSort(int[] vet, int inicio, int fim)
        {
            int meio;
            if (inicio < fim)
            {
                meio = (int)((inicio + fim) / 2);
                MergeSort(vet, inicio, meio);
                MergeSort(vet, meio + 1, fim);
                Merge(vet, inicio, meio, fim);
            }
        }//Algoritmo de ordenação MergeSort

        public static int Particiona(int[] vet, int inicio, int fim)
        {
            int pivo = vet[fim];
            int i = inicio - 1;
            for (int j = inicio; j <= fim; j++)
            {
                if (vet[j] < pivo)
                {
                    i++;
                    Trocar(vet, i, j);
                }
            }
            Trocar(vet, i + 1, fim);

            return i + 1;

        }//Particiona do QuickSort

        public static void QuickSort(int[] vet, int inicio, int fim)
        {
            int pivo;
            if (fim > inicio)
            {
                pivo = Particiona(vet, inicio, fim);
                QuickSort(vet, inicio, pivo - 1);
                QuickSort(vet, pivo + 1, fim);
            }
        }//Algoritmo de ordenação QuickSort

        public static void Heapfy(int[] vet, int n, int i)
        {
            int root = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            if (l < n && vet[l] > vet[root])
            {
                root = l;
            }
            if (r < n && vet[r] > vet[root])
            {
                root = r;
            }
            if (root != i)
            {
                Trocar(vet, i, root);
                Heapfy(vet, n, root);
            }
        }//Criação MaxHeap

        public static void HeapSort(int[] vet, int tam)
        {
            for (int i = tam / 2 - 1; i >= 0; i--)
            {
                Heapfy(vet, tam, i);
            }
            for (int i = tam - 1; i > 0; i--)
            {
                Trocar(vet, 0, i);
                Heapfy(vet, i, 0);
            }
        }//Algoritmo de ordenação HeapSort

        public static void ShellSort(int[] vet, int tam)
        {
            for (int gap = tam / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < tam; i++)
                {
                    int temp = vet[i];
                    int j;
                    for (j = i; j >= gap && vet[j - gap] > temp; j -= gap)
                    {
                        vet[j] = vet[j - gap];
                    }
                    vet[j] = temp;
                }
            }
        }
    }
}

