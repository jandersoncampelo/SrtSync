using System;
using System.IO;
using System.Text.RegularExpressions;
using SrtSyncLib;
using SrtSyncLib.Model;

namespace SrtSyncConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + @"\..\..\..\Legenda_Teste.srt";
            char sinal = '+';

            int horas = 10;
            int minutos = 0;
            int segundos = 0;
            int milisegundos = 0;

            Random rnd = new Random();
            string pathDest = Directory.GetCurrentDirectory() + $"\\..\\..\\..\\Legenda_{ rnd.Next(1000, 9999) }.srt";

            var offset = new Offset(sinal, horas, minutos, segundos, milisegundos);
            SrtSync.CarregaArquivo(new StreamReader(path),
                                   offset,
                                   pathDest);

            Console.WriteLine($"A legenda sincronizada foi salva em {pathDest}");
        }
    }
}
