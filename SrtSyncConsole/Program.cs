using System;
using System.IO;
using SrtSyncLib;
using SrtSyncLib.Model;

namespace SrtSyncConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var offset = new Offset('-', 0, 0, 25, 0);
            SrtSync.CarregaArquivo(new StreamReader(@"C:\Users\Janderson\source\repos\SrtSync\SrtSyncConsole\Legenda_Teste.srt"),
                                   offset,
                                   @"C:\Users\Janderson\source\repos\SrtSync\SrtSyncConsole\Legenda_Nova.srt");

            Console.WriteLine("Hello World!");
        }
    }
}
