using System;
using System.Collections.Generic;
using System.Text;

namespace ed2
{
    public class Funcoes
    {

        public void Trocar(int[] vet, int i, int j)
        {
            int aux = vet[i];
            vet[i] = vet[j];
            vet[j] = aux;
        }//Troca duas posições em um vetor

        public void ImprimeVetor(int[] vet, int tam)
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

        public void BubbleSort(int[] vet, int tam)
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

        public void SelectionSort(int[] vet, int tam)
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

        public void InsertionSort(int[] vet, int tam)
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

        public void Merge(int[] vet, int inicio, int meio, int fim)
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

        public void MergeSort(int[] vet, int inicio, int fim)
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

        public int Particiona(int[] vet, int inicio, int fim)
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

        public void QuickSort(int[] vet, int inicio, int fim)
        {
            int pivo;
            if (fim > inicio)
            {
                pivo = Particiona(vet, inicio, fim);
                QuickSort(vet, inicio, pivo - 1);
                QuickSort(vet, pivo + 1, fim);
            }
        }//Algoritmo de ordenação QuickSort

        public void Heapfy(int[] vet, int n, int i)
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

        public void HeapSort(int[] vet, int tam)
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

        public void ShellSort(int[] vet, int tam)
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
