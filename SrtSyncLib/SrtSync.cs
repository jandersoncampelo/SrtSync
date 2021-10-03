using SrtSyncLib.Model;
using System;
using System.IO;

namespace SrtSyncLib
{
    public static class SrtSync
    {
        public static void CarregaArquivo(StreamReader arquivo, Offset offSet, string novoArquivo)
        {
            var arquivoSRT = new Arquivos();
            arquivoSRT.LerSRT(arquivo);
            arquivoSRT.Sync(offSet);

            var stremWriter = new StreamWriter(novoArquivo, true);
            arquivoSRT.GravaSRT(stremWriter);
            
        }



    }
} 
