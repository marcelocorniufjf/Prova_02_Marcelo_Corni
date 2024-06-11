using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova_02_Marcelo_Corni
{
    public class ParticaoSucessiva
    {
        public int Mediana(List<int> lista, int inicio, int fim, int k)
        {
            if (inicio <= fim)
            {
                int posicaoPivo = Particionar(lista, inicio, fim);

                if (posicaoPivo == k)
                {
                    return lista[posicaoPivo];
                }
                else if (posicaoPivo > k)
                {
                    return Mediana(lista, inicio, posicaoPivo - 1, k);
                }
                else
                {
                    return Mediana(lista, posicaoPivo + 1, fim, k);
                }
            }
            return int.MinValue;
        }

        private int Particionar(List<int> lista, int inicio, int fim)
        {
            int pivo = lista[inicio];
            int i = inicio;

            for (int j = inicio + 1; j <= fim; j++)
            {
                if (lista[j] < pivo)
                {
                    i++;
                    Trocar(lista, i, j);
                }
            }
            Trocar(lista, inicio, i);
            return i;
        }

        private void Trocar(List<int> lista, int i, int j)
        {
            int temp = lista[i];
            lista[i] = lista[j];
            lista[j] = temp;
        }
    }

}
