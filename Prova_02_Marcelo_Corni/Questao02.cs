using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova_02_Marcelo_Corni
{
    public  class Questao02
    {
        public class Nodo
        {
            public int[] Pilha { get; set; }
            public List<Nodo> Filhos { get; set; }
            public bool Vitoria { get; set; }
            public bool EhJogadorA { get; set; }

            public Nodo(int[] pilha)
            {
                Pilha = pilha;
                Filhos = new List<Nodo>();
                Vitoria = false;
                EhJogadorA = true;
            }
        }

        public void ConstruirArvoreDeProbabilidades(Nodo nodo, bool jogadorA)
        {
            nodo.EhJogadorA = jogadorA;

            // Se a pilha não puder ser dividida, termina a construção
            if (!PodeDividirPilha(nodo.Pilha))
            {
                nodo.Vitoria = !jogadorA;
                return;
            }

            // Gera todas as divisões possíveis
            List<int[]> divisoes = DividirPilha(nodo.Pilha);
            foreach (int[] divisao in divisoes)
            {
                Nodo filho = new Nodo(divisao);
                nodo.Filhos.Add(filho);
                ConstruirArvoreDeProbabilidades(filho, !jogadorA);
            }
        }

        public bool PodeDividirPilha(int[] pilha)
        {
            return pilha.Length > 1 || pilha[0] > 1;
        }

        public List<int[]> DividirPilha(int[] pilha)
        {
            List<int[]> divisoes = new List<int[]>();

            if (pilha.Length == 1 && pilha[0] >= 3)
            {
                divisoes.Add(new int[] { pilha[0] / 3, pilha[0] / 3, pilha[0] / 3 });
            }
            else if (pilha.Length == 1 && pilha[0] == 2)
            {
                divisoes.Add(new int[] { 1, 1 });
            }

            return divisoes;
        }

        public void DeterminarEstrategiaVencedora(Nodo nodo)
        {
            if (nodo.Filhos.Count == 0)
            {
                nodo.Vitoria = !nodo.EhJogadorA;
                return;
            }

            bool temFilhoPerdedor = false;
            foreach (var filho in nodo.Filhos)
            {
                DeterminarEstrategiaVencedora(filho);
                if (!filho.Vitoria)
                {
                    temFilhoPerdedor = true;
                }
            }

            nodo.Vitoria = temFilhoPerdedor;
        }

        public void ImprimirArvore(Nodo nodo, int nivel)
        {
            string indentacao = new string(' ', nivel * 4);
            string jogador = nodo.EhJogadorA ? "Jogador A" : "Jogador B";
            string resultado = nodo.Vitoria ? "Vencedor" : "Perdedor";
            Console.WriteLine($"{indentacao}Pilha: [{string.Join(", ", nodo.Pilha)}] - {jogador} - {resultado}");

            foreach (var filho in nodo.Filhos)
            {
                ImprimirArvore(filho, nivel + 1);
            }
        }
    }
}
