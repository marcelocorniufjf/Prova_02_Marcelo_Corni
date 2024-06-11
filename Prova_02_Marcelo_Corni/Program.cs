using Prova_02_Marcelo_Corni;
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        //Questão 01
        List<int> lista = new List<int> { 11, 1, 8, 5, 12, 4, 6, 7, 9, 3, 10, 2 };
        Questao01 questao01 = new Questao01();
        int mediana = questao01.Mediana(lista, 0, lista.Count - 1, lista.Count / 2);
        Console.WriteLine($"A mediana é: {mediana}");

        SaltaSaida();

        //Questão 02
        int[] pilhaInicial = { 9 };
        Questao02 questao02 = new Questao02();
        Questao02.Nodo raiz = new Questao02.Nodo(pilhaInicial);
        questao02.ConstruirArvoreDeProbabilidades(raiz, true);
        Console.WriteLine("Árvore de probabilidades construída.");
        questao02.ImprimirArvore(raiz, 0);

        questao02.DeterminarEstrategiaVencedora(raiz);

        if (raiz.Vitoria)
        {
            Console.WriteLine("O jogador A tem uma estratégia vencedora.");
        }
        else
        {
            Console.WriteLine("O jogador B tem uma estratégia vencedora.");
        }

        

        SaltaSaida();

        //Questão 03
        Dictionary<string, List<string>> sucessoresQ3 = new Dictionary<string, List<string>>()
        {
            { "S", new List<string>{ "A", "B" } },
            { "A", new List<string>{ "C" } },
            { "B", new List<string>{ "C", "D" } },
            { "C", new List<string>{ "E" } },
            { "D", new List<string>{ "E", "F" } },
            { "E", new List<string>{ "T" } },
            { "F", new List<string>{ "T" } },
            { "T", new List<string>() }
        };

        Dictionary<string, int> duracao = new Dictionary<string, int>()
        {
            { "S", 2 },
            { "A", 4 },
            { "B", 5 },
            { "C", 2 },
            { "D", 3 },
            { "E", 4 },
            { "F", 1 },
            { "T", 0 }
        };


        Questao03 questao03 = new Questao03();
        Dictionary<string, int> inicioMaisCedo = new Dictionary<string, int>();
        Dictionary<string, int> inicioMaisTarde = new Dictionary<string, int>();

        int tempoCritico = questao03.CalcularTempoCritico("S", sucessoresQ3, duracao, inicioMaisCedo);
        questao03.CalcularInicioMaisTarde("S", sucessoresQ3, duracao, inicioMaisCedo, inicioMaisTarde, tempoCritico);

        Console.WriteLine($"Tempo crítico: {tempoCritico}");
        foreach (var atividade in inicioMaisCedo.Keys)
        {
            Console.WriteLine($"Atividade: {atividade}, Início mais cedo: {inicioMaisCedo[atividade]}, Início mais tarde: {inicioMaisTarde[atividade]}");
        }

        SaltaSaida();

        //Questão 04
        Dictionary<string, List<string>> sucessoresQ4 = new Dictionary<string, List<string>>()
        {
            { "S", new List<string>{ "A", "B" } },
            { "A", new List<string>{ "C" } },
            { "B", new List<string>{ "C", "D" } },
            { "C", new List<string>{ "E" } },
            { "D", new List<string>{ "E", "F" } },
            { "E", new List<string>{ "T" } },
            { "F", new List<string>{ "T" } },
            { "T", new List<string>() }
        };

        Questao04 questao04 = new Questao04();

        List<List<string>> caminhos = questao04.EncontrarCaminhos("S", "T", sucessoresQ4);
        foreach (var caminho in caminhos)
        {
            Console.WriteLine(string.Join(" -> ", caminho));
        }

        Console.ReadLine();
    }

    private static void SaltaSaida() {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
    }
}