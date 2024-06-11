using Prova_02_Marcelo_Corni;
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        //Questão 01
        List<int> lista = new List<int> { 11, 1, 8, 5, 12, 4, 6, 7, 9, 3, 10, 2 };
        ParticaoSucessiva particao = new ParticaoSucessiva();
        int mediana = particao.Mediana(lista, 0, lista.Count - 1, lista.Count / 2);
        Console.WriteLine($"A mediana é: {mediana}");

        Console.ReadLine();
    }
}