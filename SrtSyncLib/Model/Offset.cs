using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrtSyncLib.Model
{
    public class Offset
    {
        public char Sinal { get; set; }
        public int Horas { get; set; }
        public int Minutos { get; set; }
        public int Segundos { get; set; }
        public int Nanosegundos { get; set; }

        public Offset(char sinal, int horas, int minutos, int segundos, int nanosegundos)
        {
            Sinal = sinal;
            Horas = horas;
            Minutos = minutos;
            Segundos = segundos;
            Nanosegundos = nanosegundos;
        }
    }
}
