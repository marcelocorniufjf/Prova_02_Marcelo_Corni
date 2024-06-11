using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova_02_Marcelo_Corni
{
    public  class Questao04
    {
        public List<List<string>> EncontrarCaminhos(string raiz, string alvo, Dictionary<string, List<string>> sucessores)
        {
            List<List<string>> todosCaminhos = new List<List<string>>();
            List<string> caminhoAtual = new List<string>();

            EncontrarCaminhosRecursivo(raiz, alvo, sucessores, caminhoAtual, todosCaminhos);
            return todosCaminhos;
        }

        private void EncontrarCaminhosRecursivo(string atual, string alvo, Dictionary<string, List<string>> sucessores, List<string> caminhoAtual, List<List<string>> todosCaminhos)
        {
            caminhoAtual.Add(atual);

            if (atual == alvo)
            {
                todosCaminhos.Add(new List<string>(caminhoAtual));
            }
            else
            {
                foreach (var sucessor in sucessores[atual])
                {
                    EncontrarCaminhosRecursivo(sucessor, alvo, sucessores, caminhoAtual, todosCaminhos);
                }
            }

            caminhoAtual.RemoveAt(caminhoAtual.Count - 1);
        }
    }
}
