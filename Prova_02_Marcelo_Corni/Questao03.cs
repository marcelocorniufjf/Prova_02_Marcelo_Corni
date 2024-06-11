using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova_02_Marcelo_Corni
{
    public class Questao03
    {
        public int CalcularTempoCritico(string atividade, Dictionary<string, List<string>> sucessores, Dictionary<string, int> duracao, Dictionary<string, int> inicioMaisCedo)
        {
            if (inicioMaisCedo.ContainsKey(atividade))
            {
                return inicioMaisCedo[atividade];
            }

            int tempo = 0;
            foreach (var sucessor in sucessores[atividade])
            {
                tempo = Math.Max(tempo, CalcularTempoCritico(sucessor, sucessores, duracao, inicioMaisCedo));
            }

            inicioMaisCedo[atividade] = tempo + duracao[atividade];
            return inicioMaisCedo[atividade];
        }

        public void CalcularInicioMaisTarde(string atividade, Dictionary<string, List<string>> sucessores, Dictionary<string, int> duracao, Dictionary<string, int> inicioMaisCedo, Dictionary<string, int> inicioMaisTarde, int tempoCritico)
        {
            if (inicioMaisTarde.ContainsKey(atividade))
            {
                return;
            }

            if (sucessores[atividade].Count == 0)
            {
                inicioMaisTarde[atividade] = tempoCritico - duracao[atividade];
            }
            else
            {
                int tempo = int.MaxValue;
                foreach (var sucessor in sucessores[atividade])
                {
                    CalcularInicioMaisTarde(sucessor, sucessores, duracao, inicioMaisCedo, inicioMaisTarde, tempoCritico);
                    tempo = Math.Min(tempo, inicioMaisTarde[sucessor]);
                }
                inicioMaisTarde[atividade] = tempo - duracao[atividade];
            }
        }
    }
}
