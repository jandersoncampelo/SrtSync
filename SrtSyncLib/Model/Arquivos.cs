using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrtSyncLib.Model
{
    public class Arquivos
    {
        public List<Legendas> Legendas { get; set; } = new List<Legendas>();

        public void Sync(Offset offSet)
        {
            foreach (var legenda in Legendas)
            {
                if (offSet.Sinal == '+')
                {
                    legenda.Inicio += new TimeSpan(0, offSet.Horas, offSet.Minutos, offSet.Segundos, offSet.Nanosegundos);
                    legenda.Fim += new TimeSpan(0, offSet.Horas, offSet.Minutos, offSet.Segundos, offSet.Nanosegundos);
                }
                else
                {
                    legenda.Inicio -= new TimeSpan(0, offSet.Horas, offSet.Minutos, offSet.Segundos, offSet.Nanosegundos);
                    if (legenda.Inicio < new TimeSpan(0, 0, 0, 0, 0))
                        legenda.Inicio = new TimeSpan(0, 0, 0, 0, 0);

                    legenda.Fim -= new TimeSpan(0, offSet.Horas, offSet.Minutos, offSet.Segundos, offSet.Nanosegundos);
                    if (legenda.Fim < new TimeSpan(0, 0, 0, 0, 0))
                        legenda.Fim = new TimeSpan(0, 0, 0, 0, 0);
                }
            }
        }
        public void LerSRT(StreamReader file)
        {
            string line = file.ReadLine();
            while (line != null)
            {
                var legenda = new Legendas();
                int ordem;
                if (int.TryParse(line, out ordem))
                {
                    legenda.Ordem = ordem;
                    line = file.ReadLine();
                }
                if (line.Contains("-->"))
                {
                    legenda.Inicio = new TimeSpan(0,     // Dias   
                        int.Parse(line.Substring(0, 2)), // Horas
                        int.Parse(line.Substring(3, 2)), // Minutos
                        int.Parse(line.Substring(6, 2)), // Segundos 
                        int.Parse(line.Substring(9, 3))  // Mili Segundos
                        );

                    legenda.Fim = new TimeSpan(0,         // Dias
                        int.Parse(line.Substring(17, 2)), // Horas
                        int.Parse(line.Substring(20, 2)), // Minutos
                        int.Parse(line.Substring(23, 2)), // Segundos 
                        int.Parse(line.Substring(26, 3))  // Mili Segundos
                        );
                    line = file.ReadLine();
                }

                while (line != "")
                {
                    legenda.Texto += line + "\n";
                    line = file.ReadLine();
                }
                line = file.ReadLine();
                Legendas.Add(legenda);
            }
        }
        public void GravaSRT(StreamWriter file)
        {
            using (file)
            {
                foreach (var legenda in Legendas)
                {
                    file.WriteLine(legenda.Ordem.ToString());
                    file.WriteLine(legenda.Inicio.ToString("hh\\:mm\\:ss\\,fff") + " --> " + legenda.Fim.ToString("hh\\:mm\\:ss\\,fff"));
                    file.WriteLine(legenda.Texto);
                }
            }
        }
    }
}
