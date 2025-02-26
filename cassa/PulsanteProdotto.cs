using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cassa
{
    internal class PulsanteProdotto:Button
    {
        private int indice;

        public int Indice { get => indice; set => indice = value; }
    }
}
