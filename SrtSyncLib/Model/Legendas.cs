using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrtSyncLib.Model
{
    public class Legendas
    {
        public int Ordem { get; set; }
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fim { get; set; }
        public string Texto { get; set; }
    }
}
