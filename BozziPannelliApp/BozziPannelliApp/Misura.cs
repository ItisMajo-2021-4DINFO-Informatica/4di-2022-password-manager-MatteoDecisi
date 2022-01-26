using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BozziPannelliApp
{
    class Misura
    {
        public float Tensione { get; set; }
        public float Corrente { get; set; }
        public string Ora { get; set; }
        public string Minuti { get; set; }

        public float Potenza()
        {
            return Tensione * Corrente;
        }
    }
}
